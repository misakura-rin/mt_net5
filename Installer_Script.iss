; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Mapping Tools"
#define MyAppVersion "0.0.0.0"
#define MyAppPublisher "OliBomby"
#define MyAppURL "https://mappingtools.github.io/"
#define MyAppExeName "Mapping Tools Installer.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{50E2DF2A-2D83-4958-B5A6-EBFD651B9CA7}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=.\
OutputBaseFilename=mapping-tools
SetupIconFile=.\Mapping_Tools_Net5\Data\mt_icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\EditorReader.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.deps.json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.runtimeconfig.dev.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Mapping_Tools_Net5.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\MaterialDesignColors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\MaterialDesignThemes.Wpf.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Microsoft.WindowsAPICodePack.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Microsoft.WindowsAPICodePack.Shell.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\NAudio.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\NAudio.Vorbis.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\NonInvasiveKeyboardHookLibrary.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\NVorbis.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\OggVorbisEncoder.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Onova.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\OsuMemoryDataProvider.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Overlay.NET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\Process.NET.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\ProcessMemoryDataFinder.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\SharpDX.Direct2D1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\SharpDX.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\SharpDX.DXGI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Mapping_Tools_Net5\bin\Release\net5.0-windows\SHARPDX.Mathematics.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

