#!/usr/bin/env bash

DEFAULT_BRANCH=$(git remote show origin | sed -n '/HEAD branch/s/.*: //p')

CURRENT_BRANCH=$(git rev-parse --abbrev-ref HEAD)

if [[ "$DEFAULT_BRANCH" == "$CURRENT_BRANCH" ]]; then
  echo "you cannot commit to default branch: $DEFAULT_BRANCH"
  exit 1;
fi