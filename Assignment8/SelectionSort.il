  .method public hidebysig static void  SelectionSort(int32[] arr) cil managed
  {
    // 
    .maxstack  4
    .locals init (int32 V_0,           "declare" all local vars.
             int32 V_1,
             int32 V_2,
             int32 V_3,
             bool V_4)
    IL_0000:  nop
    IL_0001:  ldc.i4.0                  push 0 onto the stack
    IL_0002:  stloc.0                   store 0 as the first variable: for (int i = 0; ...
    IL_0003:  br.s       IL_0048        goto instr. 48 (for loop comparison).

    IL_0005:  nop                       do nothing (might be some breakpoint stuff?).
    IL_0006:  ldloc.0                   load i.
    IL_0007:  stloc.1                   store i in variable loc. 1: least = i;
    IL_0008:  ldloc.0                   load i.
    IL_0009:  ldc.i4.1                  push 1 onto stack.
    IL_000a:  add                       add 1 to i: i++.
    IL_000b:  stloc.2                   store in variable loc. 2: j = i + 1.
    IL_000c:  br.s       IL_0029        goto instr. 29 (inner for loop comparison).

    IL_000e:  nop                       no operation.
    IL_000f:  ldarg.0                   load arr.
    IL_0010:  ldloc.2                   load j.
    IL_0011:  ldelem.i4                 load arr[j].
    IL_0012:  ldarg.0                   load arr again.
    IL_0013:  ldloc.1                   load least.
    IL_0014:  ldelem.i4                 load arr[least].
    IL_0015:  clt                       compare less than: arr[j] < arr[least].
    IL_0017:  ldc.i4.0                  push 0 onto the stack.
    IL_0018:  ceq                       compare equals, push result on stack.
    IL_001a:  stloc.s    V_4
    IL_001c:  ldloc.s    V_4
    IL_001e:  brtrue.s   IL_0024        if true (or rather 1) goto instr. 24.

    IL_0020:  nop                       no operation.
    IL_0021:  ldloc.2                   load j.
    IL_0022:  stloc.1                   store j in least: least = j.
    IL_0023:  nop
    IL_0024:  nop                       no operation.
    IL_0025:  ldloc.2                   load j.
    IL_0026:  ldc.i4.1                  push 1 onto the stack.
    IL_0027:  add                       j + 1.
    IL_0028:  stloc.2                   store result as "new" j: j++.
    IL_0029:  ldloc.2                   load j (same as outer for loop, just with j).
    IL_002a:  ldarg.0                   load arr.
    IL_002b:  ldlen                     load arr.Length.
    IL_002c:  conv.i4                   convert to int32.
    IL_002d:  clt                       j < arr.Length.
    IL_002f:  stloc.s    V_4
    IL_0031:  ldloc.s    V_4
    IL_0033:  brtrue.s   IL_000e        goto for loop inner code, if j < arr.Length == true.

    IL_0035:  ldarg.0                   load arr.
    IL_0036:  ldloc.0                   load i.
    IL_0037:  ldelem.i4                 load arr[i].
    IL_0038:  stloc.3                   store result as tmp: tmp = arr[i].
    IL_0039:  ldarg.0                   load arr.
    IL_003a:  ldloc.0                   load i.
    IL_003b:  ldarg.0                   load arr again.
    IL_003c:  ldloc.1                   load arr[least].
    IL_003d:  ldelem.i4                 load arr[least].
    IL_003e:  stelem.i4                 store arr[least] in arr[i]: arr[i] = arr[least].
    IL_003f:  ldarg.0                   load arr once again.
    IL_0040:  ldloc.1                   load least.
    IL_0041:  ldloc.3                   load tmp.
    IL_0042:  stelem.i4                 store tmp in arr[least]: arr[least] = tmp.
    IL_0043:  nop                       yay, no operation.
    IL_0044:  ldloc.0                   load i.
    IL_0045:  ldc.i4.1                  push i onto the stack. 
    IL_0046:  add                       i + 1.
    IL_0047:  stloc.0                   store result in i: i++.
    IL_0048:  ldloc.0                   load variable on loc. 0: i.
    IL_0049:  ldarg.0                   load the first argument passed to the function: arr.
    IL_004a:  ldlen                     load the length of the argument: arr.Length
    IL_004b:  conv.i4                   convert to int32, push the int onto the stack.
    IL_004c:  clt                       compare values on stack less-than, push result: i < arr.Length
    IL_004e:  stloc.s    V_4            
    IL_0050:  ldloc.s    V_4            
    IL_0052:  brtrue.s   IL_0005        goto for loop inner code, if i < arr.Length == true.

    IL_0054:  ret
  } // end of method Lol::SelectionSort
