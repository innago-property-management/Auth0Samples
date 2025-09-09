# Innago.Security.IdpClient

## Pod Config

TLS and ports can and should be set via environment variables.

Ports 8080 and 8443 are conventionally used to avoid needing to run as `root`.

```yaml

containerEnvironmentVariables:
  - name: ASPNETCORE_URLS
    value: "https://*:8443;http://*:8080"
  - name: COMPlus_EnableDiagnostics
    value: "0"
  - name: ASPNETCORE_HOSTBUILDER_RELOADCONFIGONCHANGE
    value: "false"
  - name: kestrel__certificates__default__path
    value: /app/certs/tls.crt
  - name: kestrel__certificates__default__keyPath
    value: /app/certs/tls.key

```

## Sample usage

### Getting methods in the user service:

```bash
grpcurl localhost:7122 describe user.User

user.User is a service:
service User {
  rpc AssignRole ( .user.UserRoleRequest ) returns ( .user.UserReply );
  rpc ChangePassword ( .user.UserChangePasswordRequest ) returns ( .user.UserReply );
  rpc GetUserMetadata ( .user.UserMetadataRequest ) returns ( .user.UserMetadataReply );
  rpc InitiateForcedLogin ( .user.UserRequest ) returns ( .user.UserReply );
  rpc InitiateLegalHold ( .user.UserRequest ) returns ( .user.UserReply );
  rpc InitiateLockout ( .user.UserRequest ) returns ( .user.UserReply );
  rpc InitiatePasswordReset ( .user.UserRequest ) returns ( .user.UserReply );
  rpc MarkAsFraud ( .user.UserRequest ) returns ( .user.UserReply );
  rpc MarkAsSuspicious ( .user.UserRequest ) returns ( .user.UserReply );
  rpc RemoveRole ( .user.UserRoleRequest ) returns ( .user.UserReply );
  rpc ToggleMfa ( .user.UserMFARequest ) returns ( .user.UserReply );
}

```

### Getting information about a method:

```bash
grpcurl localhost:7122 describe user.User.GetUserMetadata

user.User.GetUserMetadata is a method:
rpc GetUserMetadata ( .user.UserMetadataRequest ) returns ( .user.UserMetadataReply );
```

### Getting information about a message:

```bash
grpcurl localhost:7122 describe user.UserMetadataRequest

user.UserMetadataRequest is a message:
message UserMetadataRequest {
  string email = 1;
  optional .user.KeysWrapper keys = 2;
}

grpcurl localhost:7122 describe user.KeysWrapper
user.KeysWrapper is a message:
message KeysWrapper {
  repeated string key = 1;
}

```

### Get User Metadata

#### All fields

```bash
grpcurl -d '{"email": "zzz@yopmail.com"}' localhost:7122  user.User.GetUserMetadata
```
```json
{
    "metadata": {
        "full_name": "zzz@yopmail.com",
        "identity_id": "18263d83...",
        "...": "..."
    }
}

```

#### Specified fields using optional argument

```bash

grpcurl -d '{"email": "zzz@yopmail.com", "keys": [ {"key":"organizationuid"}]}' localhost:7122  user.User.GetUserMetadata
````
```json
{
  "metadata": {
    "organizationuid": "4fa..."
  }
}

```

## Required Scopes

- create:user_attribute_profiles
- create:user_custom_blocks
- create:user_tickets
- create:users
- create:users_app_metadata
- read:tenant_settings
- read:user_attribute_profiles
- read:user_custom_blocks
- read:user_idp_tokens
- read:users
- read:users_app_metadata
- update:user_attribute_profiles
- update:users
- update:users_app_metadata
