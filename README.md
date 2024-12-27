# NumiX
Developing a calculator as a mobile app using .NET 8.0 MAUI a cross platform framework developed by Microsoft and C# for programming.



*Currently in Development
Hopefully this C# doesn't kill me along the way*


## Calculator Design Overview
1. **Layout Description**

**Mode Toggle Buttons**: At the top or side, a toggle/switch lets users switch between Scientific, Standard, and Programmer modes.
Screen: A large, high-resolution display for results and input, accommodating multiline output for scientific and programmer operations.
Buttons: Organized differently for each mode but unified in aesthetics and feel.
Body Design: Sleek, modern, with minimalistic aesthetics.

2. **Functional Area Layout**

Here’s a detailed breakdown of the sections for each mode:

## Standard Mode
### Buttons/Features:

- Numerical Input: `0–9` keys.
- Basic Operations: `+`, `-`, `*`, `/`, `%`, `=`.
- Utility Keys: `CE`, `C`, `DEL`, `.`.
- Memory Functions: `M+`, `M-`, `MR`, `MC`.

## Scientific Mode

### Additional Features:

- **Trigonometric Functions**: `sin`, `cos`, `tan`, and their inverses.
- **Logarithmic Functions**: `log`, `ln`, `10^x^`, `e^x^`.
- **Exponents and Roots**: `x^y^`, `x^2^`, `√x`, `n!`.
- **Constants**: `π`, `e`.
- **Angle Units**: Toggle between RAD, DEG.
- **Parentheses**: `(`, `)`.
- **Complex Numbers**: `i` for imaginary numbers.
- **Scientific Notation**: `EXP`.

## Programmer Mode
### Additional Features:

- **Number Systems**: Switch between `BIN`, `OCT`, `DEC`, `HEX`.
- **Bitwise Operators**: `AND`, `OR`, `XOR`, `NOT`, `SHIFT LEFT (<<)`, `SHIFT RIGHT (>>)`.
- **Hexadecimal Keys**: `A–F`.
- **Logical Operators**: `<`, `>`, `=`.
- **Byte View**: Display binary/hexadecimal representation in byte form.
- **Character Conversion**: Convert between `ASCII` and numeric forms.