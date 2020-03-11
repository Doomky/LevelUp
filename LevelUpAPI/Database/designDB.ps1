
#If this command does not work try to delete your classes in Model folder
$json = Get-Content 'appsettings.json' | Out-String | ConvertFrom-Json
Scaffold-DbContext $json.ConnectionStrings[0].DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Model