# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a C# implementation of "The Ray Tracer Challenge" by Jamis Buck. The project implements a 3D ray tracer from scratch, following a test-driven development approach.

**Book Reference**: http://103.203.175.90:81/fdScript/RootOfEBooks/E%20Book%20collection%20-%202025%20-%20C/RARE%20BOOKS/The_Ray_Tracer_Challenge_Jamis_Buck_Pragmatic_Bookshelf,_2019.pdf

## Solution Structure

- **src/The-Ray-Tracer-Challenge/**: Core ray tracer library containing fundamental classes
- **test/The-Ray-Tracer-Challenge.Tests/**: XUnit test suite
- **samples/**: Example applications demonstrating library usage
- **benchmarks/**: Performance benchmarking project

## Key Components

The core library is built around mathematical primitives:
- `Tuple`: 4D homogeneous coordinate system (x,y,z,w) - foundation for points and vectors
- `Point`: 3D position (w=1) 
- `Vector`: 3D direction (w=0)
- `Matrix`: 4x4 transformation matrices with operator overloading
- `Transform`: Static methods for translation, scaling, rotation, and shearing
- `Color`: RGB color representation with arithmetic operations
- `Canvas`: 2D pixel buffer for rendering
- Image formatters for exporting (PPM format implemented)

## Development Commands

### Building
```bash
dotnet build
```

### Running Tests
```bash
# Run all tests
dotnet test

# Run tests for specific project
dotnet test test/The-Ray-Tracer-Challenge.Tests/

# Run specific test method
dotnet test --filter "TestMethodName"
```

### Running Samples
```bash
# Run projectile simulation
dotnet run --project samples/Projectile/

# Run projectile with plotting
dotnet run --project samples/Projectile-Plotting/
```

### Running Benchmarks
```bash
dotnet run --project benchmarks/The-Ray-Tracer-Challenge.Benchmarks/ -c Release
```

## Architecture Notes

- Uses .NET 9.0 target framework
- Heavy use of value types (structs) for performance
- Custom double equality comparer for floating-point comparisons (`DoubleEqualityComparer`)
- Extensive operator overloading for mathematical operations
- Implicit conversions between related types (Tuple ↔ Point/Vector/Matrix)
- Extension methods in `Extensions/` folder for additional functionality
- Test-driven development with comprehensive XUnit test coverage using NooBIT.Asserts for fluent assertions

The codebase follows the structure and exercises from the book, building a ray tracer incrementally chapter by chapter.