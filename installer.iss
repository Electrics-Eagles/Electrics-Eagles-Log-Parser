; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "ElectricsEaglesWinFormsLogAnalyserFramework"
#define MyAppVersion "1.0"
#define MyAppPublisher "Electrics Eagles Team "
#define MyAppURL "https://github.com/Electrics-Eagles/PiElectricsEagles"
#define MyAppExeName "ElectricsEaglesWinFormsLogAnalyserFramework.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{C4E53830-E052-45F8-9760-0E60DD760244}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=C:\Users\ProAdmin\source\repos\ElectricsEaglesWinFormsLogAnalyserFramework\ElectricsEaglesWinFormsLogAnalyserFramework\bin\Release\licnece.txt
InfoAfterFile=C:\Users\ProAdmin\source\repos\ElectricsEaglesWinFormsLogAnalyserFramework\ElectricsEaglesWinFormsLogAnalyserFramework\bin\Release\info.rtf
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\ProAdmin\OneDrive\Документы\WorkOnWindows\Software
OutputBaseFilename=ElectricsEaglesWinFormsLogAnalyserFramework_Setup_x64.exe
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\ProAdmin\source\repos\ElectricsEaglesWinFormsLogAnalyserFramework\ElectricsEaglesWinFormsLogAnalyserFramework\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\ProAdmin\source\repos\ElectricsEaglesWinFormsLogAnalyserFramework\ElectricsEaglesWinFormsLogAnalyserFramework\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

