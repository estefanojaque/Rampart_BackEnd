﻿namespace Rampart_BackEnd.IAM.Domain.Model.Commands;

public record SignInCommand(string username, string password);