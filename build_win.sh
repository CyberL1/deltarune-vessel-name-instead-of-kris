#!/usr/bin/env bash

# Require: xdelta (https://github.com/jmacd/xdelta/releases)
# Usage: ./build_win.sh path/to/xdelta path/to/original_data.win path/to/file.xdelta path/to/modded_data.win

CLI_PATH=$1
ORIGINAL_DATA_PATH=$2
MODDED_DATA_PATH=$3
XDELTA_FILE_PATH=$4

if test -z $CLI_PATH || test -z $ORIGINAL_DATA_PATH || test -z $XDELTA_FILE_PATH || test -z $MODDED_DATA_PATH; then
  echo "Usage: $0 path/to/xdelta path/to/original_data.win path/to/file.xdelta path/to/modded_data.win"
  exit 1
fi

$CLI_PATH -ds $ORIGINAL_DATA_PATH $MODDED_DATA_PATH $XDELTA_FILE_PATH
