set config=%1
if "%config%" == "" (
   set config=release
)
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild Build\Build.proj /p:Configuration="%config%"