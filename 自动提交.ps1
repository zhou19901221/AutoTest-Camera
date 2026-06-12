$env:Path += ";C:\Program Files\GitHub CLI"

$项目路径 = "F:\测试项目\自动测试"
$监控间隔 = 10

Write-Host "开始监控项目变更，每 $监控间隔 秒检查一次..." -ForegroundColor Green
Write-Host "按 Ctrl+C 停止监控" -ForegroundColor Yellow

while ($true) {
    Set-Location $项目路径
    
    $状态 = git status --porcelain
    $有变更 = $状态.Count -gt 0
    
    if ($有变更) {
        $时间戳 = Get-Date -Format "yyyy-MM-dd HH:mm:ss"
        Write-Host "[$时间戳] 检测到变更，正在提交..." -ForegroundColor Cyan
        
        git add .
        
        $变更文件 = git status --porcelain
        $提交信息 = "自动提交: " + ($变更文件.Count) + " 个文件变更"
        
        git commit -m $提交信息
        git push origin master
        
        Write-Host "[$时间戳] 提交完成" -ForegroundColor Green
        Write-Host "变更文件:" -ForegroundColor Yellow
        $变更文件 | ForEach-Object { Write-Host "  $_" }
        Write-Host ""
    }
    
    Start-Sleep -Seconds $监控间隔
}