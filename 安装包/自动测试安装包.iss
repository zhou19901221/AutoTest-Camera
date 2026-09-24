#define MyAppName "自动测试"
#define MyAppExeName "自动测试.exe"
#define MyAppPublisher "AutoTest"
#define MyAppURL "https://github.com/zhou19901221/AutoTest-Camera"
#define MyAppVersion "1.0.0"
#define MyAppId "{D2F8D8A2-4DB9-4EA6-8A94-C8D1AF8350B6}"
#define PublishDir "..\publish\win-x64\"

[Setup]
AppId={#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=
OutputDir=.
OutputBaseFilename=自动测试_安装包_{#MyAppVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
UninstallDisplayIcon={app}\{#MyAppExeName}

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "创建桌面快捷方式"; GroupDescription: "附加任务:"; Flags: unchecked

[Files]
Source: "{#PublishDir}*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "启动 {#MyAppName}"; Flags: nowait postinstall skipifsilent

[Code]
function IsDotNetDesktop8Installed(): Boolean;
var
  Version: string;
begin
  Result := False;
  if RegQueryStringValue(HKLM64,
	'SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedfx\Microsoft.WindowsDesktop.App',
	'Version', Version) then
  begin
	Result := ComparePackedVersion(Version, '8.0.0') >= 0;
  end;
end;

function InitializeSetup(): Boolean;
var
  ResultCode: Integer;
begin
  if not IsDotNetDesktop8Installed() then
  begin
	MsgBox(
	  '检测到此电脑未安装 .NET 8 Desktop Runtime（x64）。'#13#10#13#10 +
	  '请先安装后再继续安装本软件。',
	  mbError, MB_OK);
	ShellExec('open', 'https://dotnet.microsoft.com/zh-cn/download/dotnet/8.0/runtime', '', '', SW_SHOWNORMAL, ewNoWait, ResultCode);
	Result := False;
	Exit;
  end;

  Result := True;
end;
