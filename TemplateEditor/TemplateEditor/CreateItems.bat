@echo off
for /f "delims=" %%i in ('dir /b ItemProtos "ItemProtos/*.proto"') do protogen -i:ItemProtos/%%i -o:Items/%%~ni.cs
pause