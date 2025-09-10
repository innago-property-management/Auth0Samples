#!/usr/bin/env bash

dotnet clean; dotnet build | grep " RS0016" | sed -E "s/.*Symbol '(.+)' .*/\1/" | clip 