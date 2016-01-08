mono lexer-parser/fsyacc.exe --module RePar RePar.fsy
mono lexer-parser/fslex.exe --unicode ReLex.fsl
fsharpi -r lexer-parser/FsLexYacc.Runtime.dll Absyn.fs RePar.fs ReLex.fs Parse.fs
