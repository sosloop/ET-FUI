"use strict";
//FYI: https://github.com/Tencent/puerts/blob/master/doc/unity/manual.md
Object.defineProperty(exports, "__esModule", { value: true });
exports.onDestroy = exports.onPublish = void 0;
const GenCode_CSharp_1 = require("./GenCode_CSharp");
const GenCode_Hoftix_1 = require("./GenCode_Hoftix");
function onPublish(handler) {
    if (!handler.genCode) {
        console.log('gen hoftix');
        handler.genCode = false;
        (0, GenCode_Hoftix_1.genHoftixCode)(handler);
    }
    else {
        console.log('gen runtime');
        handler.genCode = false;
        (0, GenCode_CSharp_1.genCode)(handler);
    }
}
exports.onPublish = onPublish;
function onDestroy() {
    //do cleanup here
}
exports.onDestroy = onDestroy;
