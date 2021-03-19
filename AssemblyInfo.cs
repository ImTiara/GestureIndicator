using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(GestureIndicator.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(GestureIndicator.BuildInfo.Company)]
[assembly: AssemblyProduct(GestureIndicator.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + GestureIndicator.BuildInfo.Author)]
[assembly: AssemblyTrademark(GestureIndicator.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(GestureIndicator.BuildInfo.Version)]
[assembly: AssemblyFileVersion(GestureIndicator.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(GestureIndicator.GestureIndicator), GestureIndicator.BuildInfo.Name, GestureIndicator.BuildInfo.Version, GestureIndicator.BuildInfo.Author, GestureIndicator.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame("VRChat", "VRChat")]