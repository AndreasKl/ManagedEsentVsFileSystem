ManagedEsentVsFileSystem
========================
While working on a project with a massive amount of small xml docs stored in temp files, this poc should
validate the idea to store these files in ESENT instead of storing the docs on a hdd. Test were executed with 
an cheap external Samsung 2TB HDD / USB 3.0.

> Starting test with size '1024' bytes and '1000' runs.  
> FileSystem: 00:00:03.9805850  
> Esent: 00:00:00.2578887  
> Starting test with size '2048' bytes and '1000' runs.  
> FileSystem: 00:00:04.4507184  
> Esent: 00:00:00.2061388  
> Starting test with size '4096' bytes and '1000' runs.  
> FileSystem: 00:00:04.3373470  
> Esent: 00:00:00.2795267  
> Starting test with size '8192' bytes and '1000' runs.  
> FileSystem: 00:00:05.1139716  
> Esent: 00:00:00.4399013

License
-------
The MIT License (MIT)

Copyright (c) 2013 Andreas Kluth  

Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
