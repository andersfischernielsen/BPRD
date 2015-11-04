mono ./lexer-parser/fsyacc.exe --module CPar CPar.fsy
mono ./lexer-parser/fslex.exe --unicode CLex.fsl
fsharpi -r ./lexer-parser/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs
