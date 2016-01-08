mono ./lexer-parser/fsyacc.exe --module CPar CPar.fsy
mono ./lexer-parser/fslex.exe --unicode CLex.fsl
fsharpi -r ./lexer-parser/FsLexYacc.Runtime.dll -r ./lexer-parser/FSharp.PowerPack.dll Absyn.fs Interp.fs Machine.fs Comp.fs CPar.fs CLex.fs Parse.fs ParseAndRun.fs ParseAndComp.fs
