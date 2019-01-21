# MemoryDiagnostics
A little graphical user interface to find memory leaks in the .net managed heap based on microsofts https://github.com/Microsoft/clrmd. Uses the first found process matching the process filter textbox to create snapshots. After this, compare the objects found in the managed heap.
If you want to analyse a 64 bit process, you have to compile this project also for 64 bit.
