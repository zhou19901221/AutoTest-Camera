param(
	[string]$Configuration = "Release",
	[string]$Runtime = "win-x64",
	[string]$Version = "1.0.0"
)

$ErrorActionPreference = "Stop"

$root = Split-Path -Parent $PSScriptRoot
$publishDir = Join-Path $root "publish\$Runtime"

Write-Host "[1/3] 发布程序到: $publishDir"
dotnet publish (Join-Path $root "自动测试.csproj") -c $Configuration -r $Runtime --self-contained false /p:PublishSingleFile=false /p:Version=$Version -o $publishDir

$issPath = Join-Path $PSScriptRoot "自动测试安装包.iss"

$innoCandidates = @(
	"${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
	"${env:ProgramFiles}\Inno Setup 6\ISCC.exe"
)

$iscc = $innoCandidates | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $iscc) {
	throw "未找到 Inno Setup 编译器 ISCC.exe，请先安装 Inno Setup 6。"
}

Write-Host "[2/3] 生成安装包"
& $iscc "/DMyAppVersion=$Version" $issPath

Write-Host "[3/3] 完成。安装包输出目录: $PSScriptRoot"
