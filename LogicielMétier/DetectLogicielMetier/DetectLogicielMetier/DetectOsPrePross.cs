
using System;

namespace DetectLogicielMetier
{

    class DetectOsPrePross
    {
        public void testMacro()
        {
#if OS_WINDOWS
            Console.WriteLine("Vous êtes sous WINDOWS");
#else
        Console.WriteLine("Vous n'êtes pas sous WINDOWS");
#endif
            
            
            
#if OS_LINUX
            Console.WriteLine("Vous êtes sous LINUX");
#else
        Console.WriteLine("Vous n'êtes pas sous LINUX");
#endif
        }
    }
    
}

/*Ne pas oubliser de mettre ca dans le fichier .cproj
 *
    <PropertyGroup Condition="$([MSBuild]::IsOSPlatform('Windows'))">
        <DefineConstants>OS_WINDOWS</DefineConstants>
    </PropertyGroup>
    <PropertyGroup Condition="$([MSBuild]::IsOSPlatform('Linux'))">
    <DefineConstants>OS_LINUX</DefineConstants>
    </PropertyGroup> 
 *
 *
 * 
 */

