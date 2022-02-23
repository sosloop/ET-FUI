//FYI: https://github.com/Tencent/puerts/blob/master/doc/unity/manual.md

import { FairyEditor } from 'csharp';
import { genCode } from './GenCode_CSharp';
import { genHoftixCode } from './GenCode_Hoftix';

function onPublish(handler: FairyEditor.PublishHandler) {
    if (!handler.genCode){
        console.log('gen hoftix');
        handler.genCode = false;
        genHoftixCode(handler);
    }else{
        console.log('gen runtime')
        handler.genCode = false;
        genCode(handler);
    }
}

function onDestroy() {
    //do cleanup here
}

export { onPublish, onDestroy };