**************************************
*        VOLUMETRIC FOG & MIST       *
* Created by Ramiro Oliva (Kronnect) * 
*            README FILE             *
**************************************


How to use this asset
---------------------
Firstly, you should run the Demo Scenes provided to get an idea of the overall functionality. There're lot of use cases where you can use Volumetric Fog & Mist, from gorgeous thick animated smoke, to thin mist above grass, dense dust storms, ...
Later, you should read the documentation and experiment with the tool.

Hint: to quick start using the asset just add VolumetricFog script to your camera. It will show up in the Game view. Customize it using the custom inspector.


Demo Scenes
-----------
There're 10+ demo scenes, located in "Demos" folder. Just go there from Unity, open them and run it. Remember to remove the Demos folder from your project to reduce size.


Documentation/API reference
---------------------------
The PDF is located in the Documentation folder. It contains instructions on how to use this asset as well as a useful Frequent Asked Question section.


Support
-------
Please read the documentation PDF and browse/play with the demo scenes and sample source code included before contacting us for support :-)

* Support: contact@kronnect.me
* Website-Forum: http://kronnect.me
* Twitter: @KronnectGames


Future updates
--------------

All our assets follow an incremental development process by which a few beta releases are published on our support forum (kronnect.com).
We encourage you to signup and engage our forum. The forum is the primary support and feature discussions medium.

Of course, all updates of Volumetric Fog & Mist will be eventually available on the Asset Store.


Version history
---------------

v7.4.2 Current Release
- Improved performance of fog color changes
- Optimizations to Sun shadows system

v7.4.1 Published 2017.07.17
- [Fix] VR: Fixed Single Pass Stereo Rendering in Unity 2017.1
- Some shader tweaks

v7.4 Published 2017.07.11
- Fog of war: clear methods now allows specifying duration of clearance to produce a smoother effect
- Added Shadow Cancellation parameter to simulate volumetric lighting effect. New demo scene 15.
- Exposed internal Sun Shadows Bias parameter which helps avoid self-shadowing
- Some shader optimizations, also removed jitter parameter as banding artifacts have been reduced

v7.3.1 Published 2017.06.01
- Added option Lighting Model under Fog Colors section
- Sun Shadows: extended tree compatibility
- Some fixes and improvements with transparency pass. Added debug toggle into inspector.

v7.3 Published 2017.05.30
- Improved transparency support, new BlendPass mode compatible with VR
- Improved look of fog over transparent objects
- Fog volumes: added option to specify custom fog colors
- Optimized shader variant count
- [Fix] Fixed downsampling fog regression bug
- [Fix] Removed console warning with Deferred rendering path + improving fog transparency option

v7.2.3b Published 2017.04.12
- Updated Dynamic Fog & Mist to version 4.0

v7.2.3 Published 2017.03.30
- Minor tweaks in fog parameters ranges to give more flexibility
- [Fix] Changes in Volumetric Fog inspector does not mark the scene as dirty ("pending save")
- [Fix] Fixed jittering changes not reflecting changes in Editor mode
- Minor fixes for Unity 5.6

V7.2.2 Published 2017.03.20
- [Fix] Fixed camera projection issue with Single Pass Stereo Rendering and OpenVR SDK

V7.2.1 Published 2017.02.17
- [Fix] Fixed regression bug with distance fog parameter

V7.2 Published 2017.02.09
- Support for orthographic camera
- New turbulence feature. Enable it under new Fog Animation section.

V7.1.1 Published 2017.02.04
- [Fix] Fixed inspector error when showing Fog of War section
- [Fix] Fixed inverted fog issue on DX11+MSAA+Downsampling

V7.1 Published 2017.02.01
- New feature: Sun shadows
- Ability to render along XY plane
- Some internal fixes and improvements

V7.0.1 Published 2017.01.20
- Proper detection of multiple render targets support when using downsampling x2 or higher
- Removed usage of reserved keyword for PS4 platform
- Fixed issue with incorrect Unity version packages on the Asset Store
- Added debug mode toggle in inspector for checking correct fog rendering
- Added reminder to disable unwanted effects in Build Options to optimize build compilation

V7.0 Published 2017.01.9
- Improved edge correction algorithm
- Downsampling up to x8 allowed
- New Depth Blur effect
- Added Point Light Check interval parameter and optimized search routine
- Added Max Distance FallOff parameter to smoothly blend fog end with sky/background
- Fixed issue with provided sprite shaders related to shadows in deferred rendering path

V6.5 Published 2016.12.2
- Fog and sky haze speed can now change smoothly without glitches
- Minor internal improvements and fixes

V6.4 Published 2016.11.16
- Inverted fog void are deprecated - now called fog areas, have a specific section in inspector
- Added Build Options to remove some shader features easily
- Improved fog distance effect

V6.3 Published 2016.10.25
- Option to copy Sun color
- Improved performance when Sun is assigned
- Fixed Sun shafts bug

V6.2 Published 2016.10.12
- Dynamic Fog & Mist upgraded to v2.3
- Fixed sun shafts incorrect intensity at night

V6.1 Published 2016.10.03
- Dynamic Fog & Mist upgraded to v2.2

V6.0 Published 2016.09.23
- Ability to render more than one fog area (inverted void area) with proper culling support. New demo scene.
- More than one Volumetric Fog & Mist script can be added per camera

V5.5 Published 2016.09.20
- Improved point light support
- Updated Dynamic Fog & Mist to version 2
- Some shader optimizations

V5.4 Published 2016.08.30
- New jittering parameter in light shaft section (allows to create smooth rays with fewer samples)
- VR: experimental support for Single Pass Stereo Rendering (Unity 5.4)
- Fixes issues when changing fog settings on a disabled camera
- Fixed fog over transparent objects (DirectX)

V5.3 Published 2016.07.15
- New dithering slider in the inspector to allow finer customization of the dithering effect.
- New jittering parameter which increases the level of control for banding artifacts
- New speed/damping parameter for baseline relative to camera option

V5.2 Published on 2016.05.24
- New dithering algorithm that applies to sky haze which contributes to extra banding reduction
- Fog of War: new params to control delay and duration of automatic fog restore after setting alpha
- Improved included alternate sprites shaders (unlit & diffuse) to accept vertex colors.
- Ability to follow a character when using fog inverted mode.
- Fixed Fog would shift height under some circumstances

V5.1 Published on 2016.05.12
- Reduced banding at low density.
- Changed Dynamic Fog & Mist Advanced shader variant to use shader model 3.0

V5.0 Published on 2016.04.27
- New "Edge Improve" option to reduce fog bleeding/pixelization over geometry edges when downsampling is increased.
- New ???Dithering??? option to reduce banding artifacts.
- Inverted areas (spherical and boxed) are now accurate and works from any view angle.
- Dynamic Fog & Mist (included in package) updated to V1.7

V4.2 Published on 2016.04.19
- New demo scenes ???High Clouds??? and ???MountainClimb???
- Improved area fog with better cloud scattering
- Can set custom colliders on Fog Volumes
- Fixed light scattering bug on DX platform when antialias is enabled

V4.1 Published on 2016.03.30
- Light scattering option (a.k.a. god rays, sun shafts or volumetric scattering)
- Improved performance when fog density is low
- Reorganized inspector settings in foldable sections
- Fixed sky haze noise sampling
- Fixed point light sampling scale

V4.0 Published on 2016.03.14
- Support for Point Light (up to 6 point lights) with auto tracking - another option for creating artistic effects. New Demo Scene.
- New Sprite materials & shaders (Sprite Fog Diffuse, Sprite Fog Unlit)
- Includes Dynamic Fog & Mist 1.5
- Can invert void areas
- Improved performance
- Fixes regarding Sun unassigment in inspector
- Integrated Dynamic Fog & Mist to avoid issues with shared resources

V3.3 Published on 2016.03.05
- Enhanced compatibility with sprite renderer

V3.2 Published on 2016.02.19
- New World Edge preset
- Compatibility with Gaia via Extension Manager
- Compatibility with Time of Day (assign Sun game object to Sun property in inspector)
- Ability to render either in front or behind transparent objects with a single click (inspector)
- Ability to assign a gameobject (character) to make the void area follow it automatically
- Ability to set the baseline of the fog automatically with Camera height.
- Button in inspector to unassign the Sun
- Improved preset auto configuration, now detects water level
- Improved falloff for distance fog when views from top or bottom
- Improved fog algorithm
- Compatibility with Render Texture (Demo Scene 3 included, check video below)
- Fixed issues with different height base lines

V3.1 Published on 2016.02.09
- Fog of War.

V3.0 Published on 2016.01.25
- Downsampling option to improve performance. Best results when fog is used as cloud layer.

V2.2 Published on 2016.01.22
- Support for boxed void areas

V2.1 Published on 2016.01.08
- Automatic light alignment with defined Sun

V2.0 Published on 2016.01.04
- Support for void areas
- Support for elevated fog & clouds

V1.2 Published on 2015.12.22
- Improved support for transparent objects

V1.1 Published on 2015.12.03
