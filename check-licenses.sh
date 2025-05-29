#! /usr/bin/env bash

nuget-license --input Auth0Samples.slnx \
  --include-shared-projects \
  --output jsonpretty \
  --allowed-license-types .github/actions/check-licenses-action/allowed-licenses.json \
  --ignored-packages .github/actions/check-licenses-action/ignored-packages.json | \
  jq '.[] | select(.ValidationErrors != null)'

