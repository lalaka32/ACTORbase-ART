﻿/// This is autogenerated code. If you wish to edit this file press Scene Names -> Save scene names in options. 
namespace Homebrew
{
public enum Scenes
{
sceneGame = 0,
sceneKernel = 1,
Cross = 2,
TL = 3
}
public static class ExtScenes	{	public static void To(this Scenes s)	{	ProcessingSceneLoad.To((int) s);	}}}
