#!/usr/bin/env bash

# Require: UndertaleModToolCli (https://github.com/UnderminersTeam/UndertaleModTool/releases)
# Usage: ./build_win.sh path/to/UndertaleModToolCli path/to/original_data.win path/to/modded_data.win

CLI_PATH=$1
ORIGINAL_DATA_PATH=$2
MODDED_DATA_PATH=$3

if test -z $CLI_PATH || test -z $ORIGINAL_DATA_PATH || test -z $MODDED_DATA_PATH; then
  echo "Usage: $0 path/to/UndertaleModToolCli path/to/data.win path/to/modded.win" 
  exit 1
fi

$CLI_PATH load $ORIGINAL_DATA_PATH -o $MODDED_DATA_PATH -s VesselNameInsteadOfKris.csx
