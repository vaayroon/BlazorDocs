# BlazorDocs

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10-512BD4.svg)](https://dotnet.microsoft.com/)

Open-source, **native Blazor** component library for document-heavy applications.
A from-scratch reimagining of the ideas behind
[Extend UI](https://github.com/extend-hq/ui), designed to run on **both Blazor
Server and Blazor WebAssembly** from a single Razor Class Library.

## Features

BlazorDocs aims to deliver 14 document-focused components:

- **PDF Viewer** - paged rendering, zoom, scroll
- **DOCX Viewer** - native OpenXML to HTML conversion
- **XLSX Viewer** - virtualized grid via ClosedXML/OpenXML
- **Bounding Box Citations** - field-level citations overlaid on the source PDF
- **Layout Blocks** - selectable OCR/layout blocks linked to the page
- **File Upload** - drag & drop, progress, validation
- **File Thumbnail** - document previews
- **E-Signature** - canvas-based signing
- **Document Splitting** - split and reorder pages
- **File System** - Finder-style file browser (icon / list / column / gallery)
- ...plus shared primitives (Button, Dialog, Select, Tooltip, ScrollArea).

## Design Principles

- **Native-first** - prefer pure C# (OpenXML, ClosedXML) over JavaScript wherever
  feasible; isolate unavoidable JS interop (pdf.js, signature canvas) behind
  clean, minimal APIs.
- **Hosting-agnostic** - identical public API on Server and WASM; interop is
  designed to minimize SignalR round-trips on Blazor Server.
- **Themeable** - CSS variables + CSS isolation, with light and dark modes.
  No Node toolchain required.
- **MIT licensed** - fully customizable, free for commercial use.

## Project Structure

```
BlazorDocs/
├── src/
│   └── BlazorDocs.UI/             # Razor Class Library (the library)
├── samples/
│   ├── BlazorDocs.Demo.Server/    # Blazor Server demo
│   └── BlazorDocs.Demo.Wasm/      # Blazor WebAssembly demo
├── tests/
│   └── BlazorDocs.Tests/          # bUnit unit tests
├── docs/
├── LICENSE
└── BlazorDocs.sln
```

## Getting Started

### Requirements
- [.NET 10 SDK](https://dotnet.microsoft.com/)

### Build & run

```bash
git clone https://github.com/<your-user>/BlazorDocs.git
cd BlazorDocs
dotnet build
dotnet test

# Run the WASM demo
dotnet run --project samples/BlazorDocs.Demo.Wasm

# or the Server demo
dotnet run --project samples/BlazorDocs.Demo.Server
```

### Using the library

```razor
@using BlazorDocs.UI

<BlazorDocsProvider Theme="ThemeMode.Light">
    <Button Variant="ButtonVariant.Primary" Size="ButtonSize.Md" OnClick="HandleClick">
        Click me
    </Button>
</BlazorDocsProvider>
```

Reference the library stylesheet once in your host page:

```html
<link href="_content/BlazorDocs.UI/blazordocs.css" rel="stylesheet" />
```

## Roadmap

Development is organized in 6 phases - see [ROADMAP.md](ROADMAP.md):

1. **Foundations** - RCL scaffolding, theming, base primitives
2. **File primitives** - File Upload, Thumbnail, File System
3. **Document viewers** - PDF, DOCX, XLSX
4. **Advanced components** - Bounding Box Citations, Layout Blocks, Splitting, E-Signature
5. **Polish** - accessibility, virtualization, dark mode
6. **Distribution** - NuGet packaging, docs, demo site

## Contributing

Contributions are welcome! Please open an issue to discuss significant changes
before submitting a PR.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE)
file for details.

> BlazorDocs is an independent project inspired by Extend UI. It is not
> affiliated with or endorsed by Extend.
