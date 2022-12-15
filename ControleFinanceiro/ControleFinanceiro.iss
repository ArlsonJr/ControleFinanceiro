[LangOptions]
LanguageName=Portuguese
LanguageID=$0416

[Languages]
Name: "portugues"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"

#define MyAppName "ControleFinanceiro"
#define MyAppFileName "ControleFinanceiro"
#define MyAppVersion GetFileVersion(".\bin\Debug\" + MyAppFileName + ".exe")
#define MyAppVerName MyAppName + " " + MyAppVersion
#define MyAppPublisher "ControleFinanceiro Corporation"
;#define MyAppIcon "LogoComprai.ico"
#define MyAppPublisherURL "http://www.google.com/compraí" 
#define MyAppUpdatesURL "http://www.google.com/compraí"
#define MyAppContact "ControleFinanceiro"
#define MyAppSupportPhone "(92)99999-9999"
#define UninstallDisplayName "ControleFinanceiro " + MyAppVersion

[Setup]
AppComments={#MyAppPublisherURL}
AppContact={#MyAppContact}
AppCopyright={#MyAppPublisher}
AppName={#MyAppName}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppPublisherURL}
AppSupportPhone={#MyAppSupportPhone}
AppSupportURL={#MyAppPublisherURL}
AppUpdatesURL={#MyAppUpdatesURL}
AppVerName={#MyAppVerName}
AppVersion={#MyAppVersion}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableDirPage=no
DisableProgramGroupPage=true
DisableWelcomePage=no
OutputBaseFilename={#MyAppFileName}-{#MyAppVersion}
SolidCompression=true
;UninstallDisplayIcon={app}\{#MyAppIcon}
UninstallDisplayName={#UninstallDisplayName}
VersionInfoCompany={#MyAppPublisher}
VersionInfoCopyright={#MyAppPublisher}
VersionInfoDescription={#MyAppName}
VersionInfoProductName={#MyAppName}
VersionInfoTextVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
;WizardImageFile=Imagens\WizImage.bmp
;WizardSmallImageFile=Imagens\WizSmallImage.bmp

[Files]
Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\ControleFinanceiro.deps.json; DestDir: {app}; Flags: ignoreversion
;Source: LogoComprai.ico; DestDir: {app}; Flags: ignoreversion
;Source: BancoDados.xml; DestDir: {app}; Flags: ignoreversion

Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\ControleFinanceiro.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\ControleFinanceiro.exe; DestDir: {app}; Flags: ignoreversion
Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\ControleFinanceiro.pdb; DestDir: {app}; Flags: ignoreversion
Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\ControleFinanceiro.runtimeconfig.json; DestDir: {app}; Flags: ignoreversion
Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\Newtonsoft.Json.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\..\ControleFinanceiro\ControleFinanceiro\bin\Debug\netcoreapp3.1\usuario.json; DestDir: {app}; flags: ignoreversion


[Dirs]
Name: "{app}"; Permissions: everyone-full

[Icons]
;Cria atalho no menu iniciar
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppFileName}.exe; WorkingDir: {app}; Comment: Acesso ao Sistema; IconIndex: 0; IconFilename: "{app}\LogoComprai.ico";

;Cria atalho na área de trabalho
Name: {userdesktop}\Compraí; Filename: {app}\{#MyAppFileName}.exe; WorkingDir: {app}; Comment: Atalho de acesso direto ao Sistema; IconIndex: 0; IconFilename: "{app}\LogoComprai.ico"

[Run]
Filename: {app}\{#MyAppFileName}.exe; Description: Executar o {#MyAppVerName}; Flags: postinstall nowait skipifsilent
Filename: {app}\{#MyAppFileName}.exe; Flags: postinstall skipifnotsilent waituntilidle

