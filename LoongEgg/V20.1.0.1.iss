; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Loong Keys"
#define MyAppVersion "20.1.0.1"
#define MyAppPublisher "Loog Egg"
#define MyAppURL "https://space.bilibili.com/14343016"
#define MyAppExeName "LoongEgg.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{5A26D139-0097-49FE-9DAA-3E32793D947F}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputBaseFilename=Loong Keys Installer
SetupIconFile=C:\Users\King\source\repos\LoongEgg\LoongEgg\egg.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\King\source\repos\LoongEgg\LoongEgg\bin\Debug\LoongEgg.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\King\source\repos\LoongEgg\LoongEgg\bin\Debug\LoongEgg.MouseKeyHook.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\King\source\repos\LoongEgg\LoongEgg\bin\Debug\LoongEgg.Presentation.Controls.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\King\source\repos\LoongEgg\LoongEgg\bin\Debug\LoongEgg.Presentation.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\King\source\repos\LoongEgg\LoongEgg\bin\Debug\LoongEgg.Presentation.Demo.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\King\source\repos\LoongEgg\LoongEgg\bin\Debug\LoongEgg.Presentation.Styles.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

