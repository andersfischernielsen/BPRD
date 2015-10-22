fslex --unicode CLex.fsl
fsyacc --module CPar CPar.fsy
fsi -r ./FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs