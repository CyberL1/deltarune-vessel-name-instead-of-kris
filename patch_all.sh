#!/usr/bin/env bash

XDELTA_CLI_PATH=$1
GAMES_PATH=$2

if test -z $XDELTA_CLI_PATH || test -z $GAMES_PATH; then
  echo "Usage: $0 path/to/xdelta path/to/games"
  exit 1
fi

echo "Patching game files"

if test -f $GAMES_PATH/DELTARUNEdemo/data.win; then
  DATA_PATH=$GAMES_PATH/DELTARUNEdemo/data.win

  xdelta -fds $DATA_PATH out/demo.xdelta $DATA_PATH.mod
  rm $DATA_PATH
  mv $DATA_PATH.mod $DATA_PATH
else
  echo $GAMES_PATH/DELTARUNEdemo/data.win not found, skipping
fi

for chapter in 1 2 3 4 5; do
  DATA_PATH=$GAMES_PATH/DELTARUNE/chapter"$chapter"_windows/data.win

  if test -f $DATA_PATH; then
    xdelta -fds $DATA_PATH out/chapter"$chapter".xdelta $DATA_PATH.mod
    rm $DATA_PATH
    mv $DATA_PATH.mod $DATA_PATH
  else
    echo $DATA_PATH not found, skipping
  fi
done

