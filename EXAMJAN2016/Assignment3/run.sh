mono ./lexer-parser/fslex.exe --unicode CLex.fsl
mono ./lexer-parser/fsyacc.exe --module CPar CPar.fsy
fsharpc -r ./lexer-parser/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ListCC.fs -o listcc.exe
