#!/usr/bin/env bash

# Require: UndertaleModToolCli (https://github.com/UnderminersTeam/UndertaleModTool/releases)
# Usage: ./patch.sh path/to/UndertaleModToolCli path/to/data.win

CLI_PATH=$1
DATA_PATH=$2

if test -z $CLI_PATH || test -z $DATA_PATH; then
  echo "Usage: $0 path/to/UndertaleModToolCli path/to/data.win" 
  exit 1
fi

$CLI_PATH load $DATA_PATH -o $DATA_PATH -s VesselNameInsteadOfKris.csx
