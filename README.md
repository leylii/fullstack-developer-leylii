# Full Stack Developer Assessment
This repository contains the assessment for the Full Stack Developer position at [Detec](https://detec.no/).
The assessment is divided into two parts: 
- c# assessment - aims to evaluate the candidate's ability to work with c# and .net core.
- Blazor assessment - aims to evaluate the candidate's ability to work with Blazor and .net core.

# 1. CSharp Assessment Implementation Guide

The candidate should arrange their implementation in the starter project [CSharpAssessment](CSharpAssessment/CSharpAssessment/). The project contains the interfaces [`IEncryptionService`](CSharpAssessment/CSharpAssessment/Services/IEncryptionService.cs) and [`IProcessingService`](CSharpAssessment/CSharpAssessment/Services/IProcessingService.cs) in the [`Services`](CSharpAssessment/CSharpAssessment/Services/) folder. The candidate should implement these interfaces and register them in the DI container.

**Follow the instructions instructions provided bellow and in the code comments to complete the tasks.**
## Overview of Interfaces

### IEncryptionService

Responsible for encrypting and decrypting data using the AES-GCM algorithm. This service should optimize for memory efficiency and minimal data copying.

### IProcessingService

Focuses on asynchronous processing of data, user management, and handling operations with concurrency support. This includes operations with timeouts and cancellation capabilities.

## Tasks

### 1. Implement `IEncryptionService`

- **Objective**: Implement the encryption and decryption methods using the AES-GCM algorithm. Ensure that the methods are memory efficient.
- **Key Requirements**:
  - Efficient memory use.
  - Correct format for encrypted and decrypted data.
  - Implementation should handle edge cases and potential exceptions.

### 2. Implement `IProcessingService`

- **Objective**: Provide robust implementations for asynchronous data processing and user management operations.
- **Key Requirements**:
  - Concurrency handling in data processing.
  - Validation rules adherence in user management methods.
  - Proper implementation of timeout and cancellation in long-running tasks.

### 3. Register Implementations in DI Container

- **Objective**: Register your implementations of `IEncryptionService` and `IProcessingService` into the .NET Core DI container.


# 2. Blazor Assessment Implementation Guide
The candidate should create a new Blazor project in the [BlazorAssessment](BlazorAssessment/) folder. The project should contain a single page that displays the components from the tasks bellow.

## Tasks

### 1. Create a Component that Displays a List of Users
- **Objective**: Create a component that displays a list of users. Each user should be displayed in a card-like format with their UserName and UserEmail visible.
- **Key Requirements**:
  - Create custom classes for the user data.
  - The component should be reusable.
  - The component should be able to display a list of users as an input parameter.
  - The component should display the UserName and UserEmail of each user.

### 2. Create a Component that Displays a User Details
- **Objective**: Create a component that displays the user details. The component should display the UserName and LastLoginDate of the user (which can be randomly generated for the purpose of this task).
- **Key Requirements**:
  - The component should be reusable.
  - The component should be able to display the user details as an input parameter.
  - The component should display the UserName and LastLoginDate of the user.
  - The selected User should be provided as an input parameter.

### 3. Interactivity between Components
- **Objective**: Add interactivity between the components. When a user is selected from the list, the user details should be displayed in the user details component.
- **Key Requirements**:
  - The user details component should be updated when a user is selected from the list.
  - The user details component should display the details of the selected user.


# Submission
The candidate should submit their implementation as a pull request to this repository. The pull request should contain the following:
- The implementation of the CSharp assessment in the `CSharpAssessment` folder.
- The implementation of the Blazor assessment in the `BlazorAssessment` folder.
- The code should be well-documented and follow best practices.