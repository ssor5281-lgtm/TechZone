#define MyAppName "TechZone"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "TechZone"
#define MyAppExeName "TechZone.exe"

[Setup]
AppId={{8B0F4A9E-6C31-4D4E-A9D2-123456789000}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\TechZone
DefaultGroupName=TechZone
OutputDir=Installer
OutputBaseFilename=TechZone-Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
SetupIconFile=bin\Release\net8.0-windows\win-x64\publish\techzone.ico
UninstallDisplayIcon={app}\TechZone.exe
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible

[Files]
Source: "bin\Release\net8.0-windows\win-x64\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\TechZone"; Filename: "{app}\TechZone.exe"; IconFilename: "{app}\techzone.ico"
Name: "{autodesktop}\TechZone"; Filename: "{app}\TechZone.exe"; IconFilename: "{app}\techzone.ico"

[Run]
Filename: "{app}\TechZone.exe"; Description: "Launch TechZone"; Flags: nowait postinstall skipifsilent
