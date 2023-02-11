using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UGFExtensions;
using UnityEngine;

namespace ET
{
	public class CodeLoader: Singleton<CodeLoader>
	{
		private Assembly model;
		const string Code_Prefix = "Assets/Bundles/Code";
		
		public void Start()
		{
			if (Define.EnableCodes)
			{
				GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
				if (globalConfig.CodeMode != CodeMode.ClientServer)
				{
					throw new Exception("ENABLE_CODES mode must use ClientServer code mode!");
				}
				
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(assemblies);
				EventSystem.Instance.Add(types);
				foreach (Assembly ass in assemblies)
				{
					string name = ass.GetName().Name;
					if (name == "Unity.Model.Codes")
					{
						this.model = ass;
					}
				}
			}
			else
			{
				byte[] assBytes;
				byte[] pdbBytes;
				if (!Define.IsEditor)
				{
					assBytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{Code_Prefix}/Model.dll.bytes");
					pdbBytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{Code_Prefix}/Model.pdb.bytes");

					if (Define.EnableIL2CPP)
					{
						HybridCLRHelper.Load();
					}
				}
				else
				{
					assBytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{Code_Prefix}/Model.dll.bytes");
					pdbBytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{Code_Prefix}/Model.pdb.bytes");
				}
			
				this.model = Assembly.Load(assBytes, pdbBytes);
				this.LoadHotfix();
			}
			
			IStaticMethod start = new StaticMethod(this.model, "ET.Entry", "Start");
			start.Run();
		}

		// 热重载调用该方法
		public void LoadHotfix()
		{
			byte[] assBytes;
			byte[] pdbBytes;
			if (!Define.IsEditor)
			{
				assBytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{Code_Prefix}/Hotfix.dll.bytes");
				pdbBytes = GameEntrys.Resource.LoadBinaryFromFileSystem($"{Code_Prefix}/Hotfix.pdb.bytes");
			}
			else
			{
				// 傻屌Unity在这里搞了个傻逼优化，认为同一个路径的dll，返回的程序集就一样。所以这里每次编译都要随机名字
				string[] logicFiles = Directory.GetFiles(Define.BuildOutputDir, "Hotfix_*.dll");
				if (logicFiles.Length != 1)
				{
					throw new Exception("Logic dll count != 1");
				}
				string logicName = Path.GetFileNameWithoutExtension(logicFiles[0]);
				assBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.dll"));
				pdbBytes = File.ReadAllBytes(Path.Combine(Define.BuildOutputDir, $"{logicName}.pdb"));
			}

			Assembly hotfixAssembly = Assembly.Load(assBytes, pdbBytes);
			
			Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(typeof (Game).Assembly, typeof(Init).Assembly, this.model, hotfixAssembly);
			
			EventSystem.Instance.Add(types);
		}
	}
}