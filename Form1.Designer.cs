namespace LFP_PROYECTO1_Basic_IDE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FilesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.crearProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearArchivoLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPageIDE = new System.Windows.Forms.TabPage();
            this.Language = new System.Windows.Forms.RichTextBox();
            this.ButtonCompile = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.RowColumn = new System.Windows.Forms.Label();
            this.IDELexer = new System.Windows.Forms.RichTextBox();
            this.tabPageAutomaton = new System.Windows.Forms.TabPage();
            this.labelRegularExpressionDefinition = new System.Windows.Forms.Label();
            this.labelRegularExpression = new System.Windows.Forms.Label();
            this.labelEnterLetter = new System.Windows.Forms.Label();
            this.labelAutomatonTransitionFunction = new System.Windows.Forms.Label();
            this.labelb = new System.Windows.Forms.Label();
            this.labela = new System.Windows.Forms.Label();
            this.labelQ2 = new System.Windows.Forms.Label();
            this.labelQ1 = new System.Windows.Forms.Label();
            this.labelQ0 = new System.Windows.Forms.Label();
            this.textBoxQ2b = new System.Windows.Forms.TextBox();
            this.textBoxQ2a = new System.Windows.Forms.TextBox();
            this.textBoxQ1b = new System.Windows.Forms.TextBox();
            this.textBoxQ1a = new System.Windows.Forms.TextBox();
            this.textBoxQ0b = new System.Windows.Forms.TextBox();
            this.textBoxQ0a = new System.Windows.Forms.TextBox();
            this.labelAutomatonFinalStates = new System.Windows.Forms.Label();
            this.labelAutomatonInitialState = new System.Windows.Forms.Label();
            this.labelAutomatonAlphabet = new System.Windows.Forms.Label();
            this.labelAutomatonStates = new System.Windows.Forms.Label();
            this.labelAutomatonDefinition = new System.Windows.Forms.Label();
            this.AutomatonStrings = new System.Windows.Forms.RichTextBox();
            this.AutomatonLog = new System.Windows.Forms.RichTextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPageIDE.SuspendLayout();
            this.tabPageAutomaton.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilesMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1153, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FilesMenu
            // 
            this.FilesMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearProyectoToolStripMenuItem,
            this.abrirProyectoToolStripMenuItem,
            this.guardarProyectoToolStripMenuItem,
            this.cerrarProyectoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.abrirArchivoToolStripMenuItem,
            this.guardarArchivoToolStripMenuItem,
            this.cerrarArchivoToolStripMenuItem,
            this.toolStripMenuItem3,
            this.abrirArchivoLogToolStripMenuItem,
            this.crearArchivoLogToolStripMenuItem,
            this.toolStripMenuItem4,
            this.cerrarToolStripMenuItem});
            this.FilesMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilesMenu.Name = "FilesMenu";
            this.FilesMenu.Size = new System.Drawing.Size(69, 21);
            this.FilesMenu.Text = "Archivos";
            // 
            // crearProyectoToolStripMenuItem
            // 
            this.crearProyectoToolStripMenuItem.Name = "crearProyectoToolStripMenuItem";
            this.crearProyectoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.crearProyectoToolStripMenuItem.Text = "Crear Proyecto";
            this.crearProyectoToolStripMenuItem.Click += new System.EventHandler(this.crearProyectoToolStripMenuItem_Click);
            // 
            // abrirProyectoToolStripMenuItem
            // 
            this.abrirProyectoToolStripMenuItem.Name = "abrirProyectoToolStripMenuItem";
            this.abrirProyectoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.abrirProyectoToolStripMenuItem.Text = "Abrir Proyecto";
            this.abrirProyectoToolStripMenuItem.Click += new System.EventHandler(this.abrirProyectoToolStripMenuItem_Click);
            // 
            // guardarProyectoToolStripMenuItem
            // 
            this.guardarProyectoToolStripMenuItem.Name = "guardarProyectoToolStripMenuItem";
            this.guardarProyectoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.guardarProyectoToolStripMenuItem.Text = "Guardar Proyecto";
            this.guardarProyectoToolStripMenuItem.Click += new System.EventHandler(this.guardarProyectoToolStripMenuItem_Click);
            // 
            // cerrarProyectoToolStripMenuItem
            // 
            this.cerrarProyectoToolStripMenuItem.Name = "cerrarProyectoToolStripMenuItem";
            this.cerrarProyectoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.cerrarProyectoToolStripMenuItem.Text = "Cerrar Proyecto";
            this.cerrarProyectoToolStripMenuItem.Click += new System.EventHandler(this.cerrarProyectoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem2.Text = "-------------------------";
            // 
            // abrirArchivoToolStripMenuItem
            // 
            this.abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            this.abrirArchivoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.abrirArchivoToolStripMenuItem.Text = "Abrir Archivo";
            this.abrirArchivoToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoToolStripMenuItem_Click);
            // 
            // guardarArchivoToolStripMenuItem
            // 
            this.guardarArchivoToolStripMenuItem.Name = "guardarArchivoToolStripMenuItem";
            this.guardarArchivoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.guardarArchivoToolStripMenuItem.Text = "Guardar Archivo";
            this.guardarArchivoToolStripMenuItem.Click += new System.EventHandler(this.guardarArchivoToolStripMenuItem_Click);
            // 
            // cerrarArchivoToolStripMenuItem
            // 
            this.cerrarArchivoToolStripMenuItem.Name = "cerrarArchivoToolStripMenuItem";
            this.cerrarArchivoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.cerrarArchivoToolStripMenuItem.Text = "Cerrar Archivo";
            this.cerrarArchivoToolStripMenuItem.Click += new System.EventHandler(this.cerrarArchivoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem3.Text = "-------------------------";
            // 
            // abrirArchivoLogToolStripMenuItem
            // 
            this.abrirArchivoLogToolStripMenuItem.Name = "abrirArchivoLogToolStripMenuItem";
            this.abrirArchivoLogToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.abrirArchivoLogToolStripMenuItem.Text = "Abrir Archivo Log";
            this.abrirArchivoLogToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoLogToolStripMenuItem_Click);
            // 
            // crearArchivoLogToolStripMenuItem
            // 
            this.crearArchivoLogToolStripMenuItem.Name = "crearArchivoLogToolStripMenuItem";
            this.crearArchivoLogToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.crearArchivoLogToolStripMenuItem.Text = "Guardar Archivo Log";
            this.crearArchivoLogToolStripMenuItem.Click += new System.EventHandler(this.crearArchivoLogToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem4.Text = "-------------------------";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPageIDE);
            this.TabControl.Controls.Add(this.tabPageAutomaton);
            this.TabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(12, 28);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1128, 567);
            this.TabControl.TabIndex = 1;
            // 
            // tabPageIDE
            // 
            this.tabPageIDE.Controls.Add(this.Language);
            this.tabPageIDE.Controls.Add(this.ButtonCompile);
            this.tabPageIDE.Controls.Add(this.Log);
            this.tabPageIDE.Controls.Add(this.RowColumn);
            this.tabPageIDE.Controls.Add(this.IDELexer);
            this.tabPageIDE.Location = new System.Drawing.Point(4, 25);
            this.tabPageIDE.Name = "tabPageIDE";
            this.tabPageIDE.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIDE.Size = new System.Drawing.Size(1120, 538);
            this.tabPageIDE.TabIndex = 0;
            this.tabPageIDE.Text = "IDE";
            this.tabPageIDE.UseVisualStyleBackColor = true;
            // 
            // Language
            // 
            this.Language.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Language.Location = new System.Drawing.Point(741, 18);
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            this.Language.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Language.Size = new System.Drawing.Size(356, 503);
            this.Language.TabIndex = 4;
            this.Language.Text = resources.GetString("Language.Text");
            // 
            // ButtonCompile
            // 
            this.ButtonCompile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCompile.Location = new System.Drawing.Point(20, 478);
            this.ButtonCompile.Name = "ButtonCompile";
            this.ButtonCompile.Size = new System.Drawing.Size(334, 43);
            this.ButtonCompile.TabIndex = 3;
            this.ButtonCompile.Text = "COMPILAR";
            this.ButtonCompile.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            this.Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Log.Location = new System.Drawing.Point(20, 330);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.Log.Size = new System.Drawing.Size(699, 128);
            this.Log.TabIndex = 2;
            this.Log.Text = "";
            // 
            // RowColumn
            // 
            this.RowColumn.AutoSize = true;
            this.RowColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowColumn.Location = new System.Drawing.Point(17, 296);
            this.RowColumn.Name = "RowColumn";
            this.RowColumn.Size = new System.Drawing.Size(86, 16);
            this.RowColumn.TabIndex = 1;
            this.RowColumn.Text = "Row, Column";
            // 
            // IDELexer
            // 
            this.IDELexer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDELexer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDELexer.Location = new System.Drawing.Point(20, 18);
            this.IDELexer.Name = "IDELexer";
            this.IDELexer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.IDELexer.Size = new System.Drawing.Size(699, 262);
            this.IDELexer.TabIndex = 0;
            this.IDELexer.Text = "";
            this.IDELexer.TextChanged += new System.EventHandler(this.IDELexer_TextChanged);
            // 
            // tabPageAutomaton
            // 
            this.tabPageAutomaton.Controls.Add(this.buttonB);
            this.tabPageAutomaton.Controls.Add(this.buttonA);
            this.tabPageAutomaton.Controls.Add(this.buttonReset);
            this.tabPageAutomaton.Controls.Add(this.labelRegularExpressionDefinition);
            this.tabPageAutomaton.Controls.Add(this.labelRegularExpression);
            this.tabPageAutomaton.Controls.Add(this.labelEnterLetter);
            this.tabPageAutomaton.Controls.Add(this.labelAutomatonTransitionFunction);
            this.tabPageAutomaton.Controls.Add(this.labelb);
            this.tabPageAutomaton.Controls.Add(this.labela);
            this.tabPageAutomaton.Controls.Add(this.labelQ2);
            this.tabPageAutomaton.Controls.Add(this.labelQ1);
            this.tabPageAutomaton.Controls.Add(this.labelQ0);
            this.tabPageAutomaton.Controls.Add(this.textBoxQ2b);
            this.tabPageAutomaton.Controls.Add(this.textBoxQ2a);
            this.tabPageAutomaton.Controls.Add(this.textBoxQ1b);
            this.tabPageAutomaton.Controls.Add(this.textBoxQ1a);
            this.tabPageAutomaton.Controls.Add(this.textBoxQ0b);
            this.tabPageAutomaton.Controls.Add(this.textBoxQ0a);
            this.tabPageAutomaton.Controls.Add(this.labelAutomatonFinalStates);
            this.tabPageAutomaton.Controls.Add(this.labelAutomatonInitialState);
            this.tabPageAutomaton.Controls.Add(this.labelAutomatonAlphabet);
            this.tabPageAutomaton.Controls.Add(this.labelAutomatonStates);
            this.tabPageAutomaton.Controls.Add(this.labelAutomatonDefinition);
            this.tabPageAutomaton.Controls.Add(this.AutomatonStrings);
            this.tabPageAutomaton.Controls.Add(this.AutomatonLog);
            this.tabPageAutomaton.Location = new System.Drawing.Point(4, 25);
            this.tabPageAutomaton.Name = "tabPageAutomaton";
            this.tabPageAutomaton.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAutomaton.Size = new System.Drawing.Size(1120, 538);
            this.tabPageAutomaton.TabIndex = 1;
            this.tabPageAutomaton.Text = "Autómata AFD";
            this.tabPageAutomaton.UseVisualStyleBackColor = true;
            // 
            // labelRegularExpressionDefinition
            // 
            this.labelRegularExpressionDefinition.AutoSize = true;
            this.labelRegularExpressionDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegularExpressionDefinition.Location = new System.Drawing.Point(440, 79);
            this.labelRegularExpressionDefinition.Name = "labelRegularExpressionDefinition";
            this.labelRegularExpressionDefinition.Size = new System.Drawing.Size(121, 31);
            this.labelRegularExpressionDefinition.TabIndex = 26;
            this.labelRegularExpressionDefinition.Text = "(b|b*a)*a";
            // 
            // labelRegularExpression
            // 
            this.labelRegularExpression.AutoSize = true;
            this.labelRegularExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegularExpression.Location = new System.Drawing.Point(440, 31);
            this.labelRegularExpression.Name = "labelRegularExpression";
            this.labelRegularExpression.Size = new System.Drawing.Size(236, 31);
            this.labelRegularExpression.TabIndex = 25;
            this.labelRegularExpression.Text = "Expresión Regular";
            // 
            // labelEnterLetter
            // 
            this.labelEnterLetter.AutoSize = true;
            this.labelEnterLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterLetter.Location = new System.Drawing.Point(861, 413);
            this.labelEnterLetter.Name = "labelEnterLetter";
            this.labelEnterLetter.Size = new System.Drawing.Size(197, 31);
            this.labelEnterLetter.TabIndex = 24;
            this.labelEnterLetter.Text = "Ingresar Letras";
            // 
            // labelAutomatonTransitionFunction
            // 
            this.labelAutomatonTransitionFunction.AutoSize = true;
            this.labelAutomatonTransitionFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutomatonTransitionFunction.Location = new System.Drawing.Point(808, 30);
            this.labelAutomatonTransitionFunction.Name = "labelAutomatonTransitionFunction";
            this.labelAutomatonTransitionFunction.Size = new System.Drawing.Size(281, 31);
            this.labelAutomatonTransitionFunction.TabIndex = 22;
            this.labelAutomatonTransitionFunction.Text = "Función de Transición";
            // 
            // labelb
            // 
            this.labelb.AutoSize = true;
            this.labelb.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelb.Location = new System.Drawing.Point(1034, 61);
            this.labelb.Name = "labelb";
            this.labelb.Size = new System.Drawing.Size(51, 55);
            this.labelb.TabIndex = 21;
            this.labelb.Text = "b";
            // 
            // labela
            // 
            this.labela.AutoSize = true;
            this.labela.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labela.Location = new System.Drawing.Point(944, 61);
            this.labela.Name = "labela";
            this.labela.Size = new System.Drawing.Size(51, 55);
            this.labela.TabIndex = 20;
            this.labela.Text = "a";
            // 
            // labelQ2
            // 
            this.labelQ2.AutoSize = true;
            this.labelQ2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQ2.Location = new System.Drawing.Point(823, 304);
            this.labelQ2.Name = "labelQ2";
            this.labelQ2.Size = new System.Drawing.Size(88, 55);
            this.labelQ2.TabIndex = 19;
            this.labelQ2.Text = "Q2";
            // 
            // labelQ1
            // 
            this.labelQ1.AutoSize = true;
            this.labelQ1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQ1.Location = new System.Drawing.Point(823, 223);
            this.labelQ1.Name = "labelQ1";
            this.labelQ1.Size = new System.Drawing.Size(88, 55);
            this.labelQ1.TabIndex = 18;
            this.labelQ1.Text = "Q1";
            // 
            // labelQ0
            // 
            this.labelQ0.AutoSize = true;
            this.labelQ0.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQ0.Location = new System.Drawing.Point(823, 147);
            this.labelQ0.Name = "labelQ0";
            this.labelQ0.Size = new System.Drawing.Size(88, 55);
            this.labelQ0.TabIndex = 17;
            this.labelQ0.Text = "Q0";
            // 
            // textBoxQ2b
            // 
            this.textBoxQ2b.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQ2b.Location = new System.Drawing.Point(1025, 297);
            this.textBoxQ2b.Name = "textBoxQ2b";
            this.textBoxQ2b.Size = new System.Drawing.Size(74, 62);
            this.textBoxQ2b.TabIndex = 16;
            this.textBoxQ2b.Text = "Q2";
            // 
            // textBoxQ2a
            // 
            this.textBoxQ2a.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQ2a.Location = new System.Drawing.Point(933, 297);
            this.textBoxQ2a.Name = "textBoxQ2a";
            this.textBoxQ2a.Size = new System.Drawing.Size(74, 62);
            this.textBoxQ2a.TabIndex = 15;
            this.textBoxQ2a.Text = "Q1";
            // 
            // textBoxQ1b
            // 
            this.textBoxQ1b.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQ1b.Location = new System.Drawing.Point(1025, 216);
            this.textBoxQ1b.Name = "textBoxQ1b";
            this.textBoxQ1b.Size = new System.Drawing.Size(74, 62);
            this.textBoxQ1b.TabIndex = 14;
            this.textBoxQ1b.Text = "Q2";
            // 
            // textBoxQ1a
            // 
            this.textBoxQ1a.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQ1a.Location = new System.Drawing.Point(933, 216);
            this.textBoxQ1a.Name = "textBoxQ1a";
            this.textBoxQ1a.Size = new System.Drawing.Size(74, 62);
            this.textBoxQ1a.TabIndex = 13;
            this.textBoxQ1a.Text = "Q1";
            // 
            // textBoxQ0b
            // 
            this.textBoxQ0b.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQ0b.Location = new System.Drawing.Point(1025, 140);
            this.textBoxQ0b.Name = "textBoxQ0b";
            this.textBoxQ0b.Size = new System.Drawing.Size(74, 62);
            this.textBoxQ0b.TabIndex = 12;
            this.textBoxQ0b.Text = "Q2";
            // 
            // textBoxQ0a
            // 
            this.textBoxQ0a.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQ0a.Location = new System.Drawing.Point(933, 140);
            this.textBoxQ0a.Name = "textBoxQ0a";
            this.textBoxQ0a.Size = new System.Drawing.Size(74, 62);
            this.textBoxQ0a.TabIndex = 11;
            this.textBoxQ0a.Text = "Q1";
            // 
            // labelAutomatonFinalStates
            // 
            this.labelAutomatonFinalStates.AutoSize = true;
            this.labelAutomatonFinalStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutomatonFinalStates.Location = new System.Drawing.Point(23, 216);
            this.labelAutomatonFinalStates.Name = "labelAutomatonFinalStates";
            this.labelAutomatonFinalStates.Size = new System.Drawing.Size(316, 31);
            this.labelAutomatonFinalStates.TabIndex = 9;
            this.labelAutomatonFinalStates.Text = "Estados Finales F = {Q1}";
            // 
            // labelAutomatonInitialState
            // 
            this.labelAutomatonInitialState.AutoSize = true;
            this.labelAutomatonInitialState.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutomatonInitialState.Location = new System.Drawing.Point(23, 171);
            this.labelAutomatonInitialState.Name = "labelAutomatonInitialState";
            this.labelAutomatonInitialState.Size = new System.Drawing.Size(219, 31);
            this.labelAutomatonInitialState.TabIndex = 8;
            this.labelAutomatonInitialState.Text = "Estado Inicial Q0";
            // 
            // labelAutomatonAlphabet
            // 
            this.labelAutomatonAlphabet.AutoSize = true;
            this.labelAutomatonAlphabet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutomatonAlphabet.Location = new System.Drawing.Point(23, 127);
            this.labelAutomatonAlphabet.Name = "labelAutomatonAlphabet";
            this.labelAutomatonAlphabet.Size = new System.Drawing.Size(283, 31);
            this.labelAutomatonAlphabet.TabIndex = 7;
            this.labelAutomatonAlphabet.Text = "Alfabeto Sigma = {a,b}";
            // 
            // labelAutomatonStates
            // 
            this.labelAutomatonStates.AutoSize = true;
            this.labelAutomatonStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutomatonStates.Location = new System.Drawing.Point(23, 79);
            this.labelAutomatonStates.Name = "labelAutomatonStates";
            this.labelAutomatonStates.Size = new System.Drawing.Size(313, 31);
            this.labelAutomatonStates.TabIndex = 6;
            this.labelAutomatonStates.Text = "Estados Q = {Q0,Q1,Q2}";
            // 
            // labelAutomatonDefinition
            // 
            this.labelAutomatonDefinition.AutoSize = true;
            this.labelAutomatonDefinition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutomatonDefinition.Location = new System.Drawing.Point(23, 31);
            this.labelAutomatonDefinition.Name = "labelAutomatonDefinition";
            this.labelAutomatonDefinition.Size = new System.Drawing.Size(326, 31);
            this.labelAutomatonDefinition.TabIndex = 5;
            this.labelAutomatonDefinition.Text = "A = {Q,Sigma,Delta,Q0,F}";
            // 
            // AutomatonStrings
            // 
            this.AutomatonStrings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutomatonStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutomatonStrings.Location = new System.Drawing.Point(19, 399);
            this.AutomatonStrings.Name = "AutomatonStrings";
            this.AutomatonStrings.ReadOnly = true;
            this.AutomatonStrings.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AutomatonStrings.Size = new System.Drawing.Size(787, 115);
            this.AutomatonStrings.TabIndex = 4;
            this.AutomatonStrings.Text = "";
            // 
            // AutomatonLog
            // 
            this.AutomatonLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AutomatonLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutomatonLog.Location = new System.Drawing.Point(19, 266);
            this.AutomatonLog.Name = "AutomatonLog";
            this.AutomatonLog.ReadOnly = true;
            this.AutomatonLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.AutomatonLog.Size = new System.Drawing.Size(787, 113);
            this.AutomatonLog.TabIndex = 3;
            this.AutomatonLog.Text = "";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(446, 169);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(230, 47);
            this.buttonReset.TabIndex = 27;
            this.buttonReset.Text = "REINICIAR";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonA
            // 
            this.buttonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonA.Location = new System.Drawing.Point(867, 467);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(109, 47);
            this.buttonA.TabIndex = 28;
            this.buttonA.Text = "a";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonA_Click);
            // 
            // buttonB
            // 
            this.buttonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonB.Location = new System.Drawing.Point(990, 467);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(109, 47);
            this.buttonB.TabIndex = 29;
            this.buttonB.Text = "b";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 610);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LFP_PROYECTO1_Basic_IDE - 200130586 Ronald Danilo Chávez Calderón";
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.tabPageIDE.ResumeLayout(false);
            this.tabPageIDE.PerformLayout();
            this.tabPageAutomaton.ResumeLayout(false);
            this.tabPageAutomaton.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FilesMenu;
        private System.Windows.Forms.ToolStripMenuItem crearProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem crearArchivoLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPageIDE;
        private System.Windows.Forms.TabPage tabPageAutomaton;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Label RowColumn;
        private System.Windows.Forms.RichTextBox IDELexer;
        private System.Windows.Forms.Button ButtonCompile;
        private System.Windows.Forms.ToolStripMenuItem guardarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarProyectoToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Language;
        private System.Windows.Forms.RichTextBox AutomatonStrings;
        private System.Windows.Forms.RichTextBox AutomatonLog;
        private System.Windows.Forms.Label labelAutomatonStates;
        private System.Windows.Forms.Label labelAutomatonDefinition;
        private System.Windows.Forms.Label labelAutomatonAlphabet;
        private System.Windows.Forms.Label labelAutomatonFinalStates;
        private System.Windows.Forms.Label labelAutomatonInitialState;
        private System.Windows.Forms.TextBox textBoxQ0a;
        private System.Windows.Forms.TextBox textBoxQ2b;
        private System.Windows.Forms.TextBox textBoxQ2a;
        private System.Windows.Forms.TextBox textBoxQ1b;
        private System.Windows.Forms.TextBox textBoxQ1a;
        private System.Windows.Forms.TextBox textBoxQ0b;
        private System.Windows.Forms.Label labelQ0;
        private System.Windows.Forms.Label labela;
        private System.Windows.Forms.Label labelQ2;
        private System.Windows.Forms.Label labelQ1;
        private System.Windows.Forms.Label labelb;
        private System.Windows.Forms.Label labelAutomatonTransitionFunction;
        private System.Windows.Forms.Label labelEnterLetter;
        private System.Windows.Forms.Label labelRegularExpressionDefinition;
        private System.Windows.Forms.Label labelRegularExpression;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonA;
    }
}

