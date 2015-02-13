Exposure Engine v2.0
Represent an exposure in a picture.

Consists of 3 major value : ISO , Aperture and Shutter Speed

ISO : Camera Sensitivity to light, represent by interger (Ex: 100 stand for ISO 100)

Aperture : How open the lens of the camera is. represent as a float x in the equation f/x 
(the higher x is, the smaller the aperture is) (ex:  aperture f/2.2 is larger than aperture f/7.5)

Shutter Speed : The amount of time, calculate in seconds, that the camera sensor is exposing to/receiving light,
usually represent in fraction of a seconds for anything smaller than 1 sec (Ex: 1/50s )



Current Limitation:
- The range of ISO, ShutterSpeed and Aperture is currently locked to 1/3 Exposure Step , this is currently acceptable with
all modern DSLR using 1/3 step system to calcuate exposure

- the range of ISO right now is hardcoded in each class due to limitation in FileAccess of Portable Class Library.
PCL Storage is installed and will be used to load the range from Assets/  in the future.