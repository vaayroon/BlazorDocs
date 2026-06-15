# BlazorDocs Roadmap

This document describes the planned development of **BlazorDocs**, organized into
six phases. The goal is a native Blazor component library for document-heavy
applications that runs on both Blazor Server and Blazor WebAssembly from a single
Razor Class Library (RCL).

**Stack decisions (fixed):**
- Target framework: `net10.0`
- Theming: CSS variables + CSS isolation (no Tailwind, no Node toolchain)
- A single shared RCL (`BlazorDocs.UI`)

---

## Phase 0 - Foundations

**Goal:** A working, verifiable skeleton in both hosting models.

- [x] Create `BlazorDocs.sln` with the project structure
  (`src/BlazorDocs.UI`, `samples/BlazorDocs.Demo.Server`,
  `samples/BlazorDocs.Demo.Wasm`, `tests/BlazorDocs.Tests`).
- [x] Enable CSS isolation in the RCL.
- [x] Theming system in `wwwroot/blazordocs.css` with CSS variables
  (colors, radii, spacing, typography) and light/dark via `[data-theme="dark"]`.
- [x] `BlazorDocsProvider` root component (theme via `CascadingValue`).
- [x] First primitive: `Button` (Variant / Size / Disabled / OnClick / ChildContent).
- [x] Home page in both samples showing Button variants and sizes.
- [x] bUnit test for Button (renders text, fires OnClick).
- [x] `README.md`, `ROADMAP.md`, `LICENSE` (MIT).

**Estimate:** 1-2 weeks.

---

## Phase 1 - Base Primitives

**Goal:** shadcn-style primitives that the document components depend on.

- [ ] `Select`
- [ ] `Dialog`
- [ ] `Tooltip`
- [ ] `ScrollArea`
- [ ] `DropdownMenu`
- [ ] `Tabs`
- [ ] Shared infrastructure: slots via `RenderFragment`, popover positioning
  (C# logic, minimal JS interop where unavoidable).

**Estimate:** 2-3 weeks.

---

## Phase 2 - File Primitives

**Goal:** quick wins with little to no JS interop.

- [ ] **File Upload** - `InputFile` + drag & drop, progress, validation.
  Abstract Server (SignalR streaming limits) vs WASM (local streams).
- [ ] **File Thumbnail** - preview generation (server-side ImageSharp on Server,
  canvas interop on WASM).
- [ ] **File System** - Finder-style browser with icon / list / column / gallery
  views and lazy async children loading (100% portable C#).

**Estimate:** 2-3 weeks.

---

## Phase 3 - Document Viewers

**Goal:** the core viewers (hardest phase).

- [ ] **DOCX Viewer** - native OpenXML SDK to HTML conversion (fully native, works on WASM).
- [ ] **XLSX Viewer** - ClosedXML/OpenXML parsing + virtualized grid via `<Virtualize>`.
- [ ] **PDF Viewer** - pdf.js encapsulated inside the RCL as a static asset
  (`_content/...`), hidden from the consumer. Move render/scroll/zoom logic to JS,
  communicate only high-level events to .NET to minimize Server round-trips.

**Estimate:** 4-6 weeks.

---

## Phase 4 - Advanced Components

**Goal:** review and agent-facing surfaces.

- [ ] **Bounding Box Citations** - SVG/CSS overlays positioned over the PDF canvas,
  synced with zoom/scroll; editable forms with `EditForm` + JSON diffing.
- [ ] **Layout Blocks** - selectable OCR blocks linked to the rendered page
  (reuses the overlay layer).
- [ ] **Document Splitting** - drag separators between pages, reordering.
- [ ] **E-Signature** - signature canvas via JS interop (pointer events to strokes),
  export to PNG/SVG.

**Estimate:** 4-5 weeks.

---

## Phase 5 - Polish

**Goal:** production readiness.

- [ ] Accessibility (ARIA, keyboard navigation).
- [ ] Page virtualization for large PDFs.
- [ ] Dark/light theming refinement.
- [ ] bUnit + Playwright tests across both hosting models.

**Estimate:** 2-3 weeks.

---

## Phase 6 - Distribution

**Goal:** make it consumable.

- [ ] Package as NuGet (`PackageLicenseExpression=MIT`).
- [ ] Optional shadcn-style "copy-source" model via a `dotnet new` template.
- [ ] Documentation with live demos.
- [ ] Publish the Blazor WASM demo site (e.g. GitHub Pages).

**Estimate:** 2-3 weeks.

---

**Total estimate:** ~4-5 months for one full-time developer.
