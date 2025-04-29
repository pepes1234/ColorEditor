# ColorEditor

![.NET 6.0](https://img.shields.io/badge/.NET-6.0-blue) ![C#](https://img.shields.io/badge/Language-C%23-blueviolet) ![WinForms](https://img.shields.io/badge/UI-WinForms-lightgrey) ![MIT License](https://img.shields.io/badge/License-MIT-lightgrey)

> Aplicativo Windows Forms para colar imagens do clipboard e manipular interativamente uma área de seleção retangular sobre a imagem.

---

## 📚 Sumário

- [Sobre o Projeto](#sobre-o-projeto)
- [Tecnologias](#tecnologias)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Uso](#uso)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Principais Componentes](#principais-componentes)
- [Contribuindo](#contribuindo)
- [Licença](#licença)

---

## 💡 Sobre o Projeto

O **ColorEditor** é uma ferramenta de desktop que permite:

- **Colar** uma imagem diretamente do **clipboard** (Ctrl+V).
- **Exibir** a imagem em um `PictureBox` com fundo branco.
- **Desenhar** uma **área de seleção retangular** sobre a imagem.
- **Mover** e **redimensionar** a seleção arrastando as bordas ou a própria área.

Ideal como base para editores de cor, crop de imagens ou qualquer aplicação que requeira seleção dinâmica sobre uma imagem.

---

## 🚀 Tecnologias

| Componente | Tecnologia                         |
|------------|------------------------------------|
| Framework  | .NET 6.0                           |
| Linguagem  | C#                                 |
| UI         | Windows Forms (WinForms)           |
| Bibliotecas| System.Drawing, System.Windows.Forms |

---

## ✅ Pré-requisitos

- Windows 10 ou superior
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- Visual Studio 2022 (ou compatível) para WinForms

---

## 🛠️ Instalação

```bash
# 1. Clone o repositório
git clone https://github.com/pepes1234/ColorEditor.git
cd "Editor de Cor winforms/Editor de Cor winforms"
# 2. Abra a solução no Visual Studio
double-click "Editor de Cor winforms.sln"
```

---

## ▶️ Uso

1. Execute o projeto no Visual Studio (F5).  
2. Na janela principal, pressione **Ctrl+V** para colar uma imagem do clipboard.  
3. Clique e arraste dentro do `PictureBox` para mover a seleção.  
4. Clique e arraste nos quadradinhos nos cantos para **redimensionar**.  
5. A seleção é atualizada em tempo real via `Timer`.

---

## 🗂️ Estrutura do Projeto

```plain
Editor de Cor winforms/           # Pasta raiz contendo o projeto WinForms
├── Editor de Cor winforms/       # Subpasta do projeto com arquivos de código
│   ├── Properties/               # Configurações do assembly
│   ├── App.config                # Configurações de runtime
│   ├── Editor de Cor winforms.csproj  # Projeto WinForms (.NET 6.0)
│   ├── Program.cs                # Ponto de entrada (Application.Run)
│   ├── Form1.Designer.cs         # Designer gerado pelo WinForms
│   ├── Form1.cs                  # Lógica de carregamento, desenho e eventos
│   ├── Form1.resx                # Recursos do formulário
│   └── README.md (este arquivo)  # Documentação do projeto
└── LICENSE                       # Licença MIT
```

---

## 🔧 Principais Componentes

- **`Program.cs`**  
  - Ponto de entrada: inicializa e exibe `Form1`.

- **`Form1.cs`**  
  - **Clipboard Paste**: captura `Ctrl+V` e cola imagem no `PictureBox`.  
  - **Timer**: loop de 25ms para redesenhar a seleção.  
  - **Seleção (Rectangle rec)**: define área móvel e redimensionável.  
  - **Eventos do `PictureBox`**:  
    - `MouseDown` / `MouseMove` / `MouseUp` para mover/redimensionar.  
    - Lógica de detecção de cantos para ajustes finos.

---