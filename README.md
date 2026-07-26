# BetterPenetration
This plugin seeks to improve HScenes in AI Shoujo, Honey Select 2, Koikatsu, and Koikatsu Sunshine by making penetration look a bit more realistic. It also adds some additional features to overall improve the HScene experience.

This is a community-maintained fork of https://github.com/Animal42069/BetterPenetration

## Installation

1. Install the latest versions of: 
    - [BepInEx v5](https://github.com/BepInEx/BepInEx/releases)
    - [BepisPlugins](https://github.com/IllusionMods/BepisPlugins/releases)
    - [IllusionModdingAPI](https://github.com/IllusionMods/IllusionModdingAPI)
2. Download the plugin from the [releases](https://github.com/IllusionMods/BetterPenetration/releases) page. Make sure it's a version for your game.
3. Extract the plugin .zip file to your game folder (where the BepInEx folder and game .exe is).

Make sure you download the version for your game (the first part before _ is the initials of the game, e.g. HS2 = HoneySelect2).

> You can get the latest nightly builds from the [CI workflow](https://github.com/IllusionMods/KK_Plugins/actions/workflows/ci.yaml). Open the latest successful run and download the build from the Artifacts section.

## Features
- Replaces the default "telescoping" behavior by allowing the head to move past the point of penetration.
- After the penis has passed the point of penetration, it will bend to avoid clipping.
- You can allow the penis to begin to squish after it has penetrated by a specified percentage
- Works for vaginal, anal, and oral penetraion.
- Maintain proper rotation of the penis, no more spinning shafts during certain positions.
- Offset options to further tweak things when using characters with abnormal body shapes.
- Supports multiple male and multiple female positions.
- Includes several male and female uncensors designed specifically for BetterPenetration, the plugin works best with those uncensors.
- Female uncensors will spread open when penetrated.  They also include individual toe bones that can be repositioned in studio.
- Penis uncensors have additional bones which allows them to bend, so they can penetrate at the correct point and still not clip.
- Ball uncensors have additional dynamic bones which are affected by gravity and will collide with the guy and the girl, drastically improving the way they look.
- Adds a push/pull effect to the mouth (all games) and vagina (HS2/AIS).  This effect pushes the mouth/vagina inward during insertion and pulls it outward during extraction.
- (HS2/AIS) Adds colliders to all characters fingers and other game objects so the vagina spreads correctly when using those objects.
- and more...

## If you are a modder

If you'd like to contribute code fixes and improvements: fork this repository, create a new branch, push your changes, and open a new PR.

To build this repository you will need VisualStudio2022+ with the `.NET desktop development` and `Game development for Unity` workloads, and `.NET Framework 3.5 development tools` + targetting packs and SDKs for at least `.NET Framework 4.6` (best to just install them all).
All dependencies are downloaded via nuget on first build of the solution. Check the wiki if you are having issues with build steps failing.
To make a release, remove old `bin` folder and rebuild the whole repo in Release configuration.

You can discuss modding on the Koikatsu Discord server in the modding channels. There are also various modding guides linked in the pins of these channels you may want to check out.
