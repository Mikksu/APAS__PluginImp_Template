@echo off
git submodule foreach --recursive git checkout develop
git submodule foreach --recursive git pull
pause