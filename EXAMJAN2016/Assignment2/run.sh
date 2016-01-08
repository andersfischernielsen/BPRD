mono ./lexer-parser/fsyacc.exe --module FunPar FunPar.fsy
mono ./lexer-parser/fslex.exe --unicode FunLex.fsl
fsharpi -r ./lexer-parser/FsLexYacc.Runtime.dll -r ./lexer-parser/FSharp.PowerPack.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs HigherFun.fs ParseAndRunHigher.fs
