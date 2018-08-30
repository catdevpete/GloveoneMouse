# GloveoneMouse
This is just a rudimentary implementation of Gloveone's C# .dll in Visual Studio.
The .exe that you build out basically allows you to move the mouse with the roll & pitch value on the accelerometer.

I will probably not work any further on this, though do let me know if you encounter any issues.

Note: Building it out will not allow it to be launched properly (I get an "FatalExecutionEngineError" when I run it from VS, even with NeuroDigital's example). I found that after I add the NDAPIWrapper.dll, I need to add in NDAPI_x86/64.dll into the location of the .exe before it can launch if it's a fresh build, and I have to run the .exe directly.

What I followed in order to get it working (with some things figured out after a while of compilation failures)
https://player.vimeo.com/video/218616304

Pre-requisite:
- Unity 2018 (specifically 2018.1.9f1) or above
- ND Suite (Link as of 30/08/2018: https://www.neurodigital.es/developer/)
