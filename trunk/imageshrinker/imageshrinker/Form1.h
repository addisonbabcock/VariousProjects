#pragma once
#include "stdafx.h"

namespace imageshrinker {

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::ListBox^  listboxLog;
	protected: 
	private: System::Windows::Forms::Label^  lblSrc;
	private: System::Windows::Forms::Label^  lblDest;
	private: System::Windows::Forms::TextBox^  txtboxSrc;
	private: System::Windows::Forms::TextBox^  txtboxDest;
	private: System::Windows::Forms::Button^  btnSelSrc;
	private: System::Windows::Forms::Button^  btnSelDest;
	private: System::Windows::Forms::Label^  lblDestWidth;
	private: System::Windows::Forms::TextBox^  txtboxDestWidth;

	private: System::Windows::Forms::Label^  lblDestHeight;
	private: System::Windows::Forms::TextBox^  txtboxDestHeight;

	private: System::Windows::Forms::Button^  btnGo;
	private: System::Windows::Forms::FolderBrowserDialog^  dlgSelSrc;
	private: System::Windows::Forms::FolderBrowserDialog^  dlgSelDest;
	private: System::Windows::Forms::Button^  btnCancel;




	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->listboxLog = (gcnew System::Windows::Forms::ListBox());
			this->lblSrc = (gcnew System::Windows::Forms::Label());
			this->lblDest = (gcnew System::Windows::Forms::Label());
			this->txtboxSrc = (gcnew System::Windows::Forms::TextBox());
			this->txtboxDest = (gcnew System::Windows::Forms::TextBox());
			this->btnSelSrc = (gcnew System::Windows::Forms::Button());
			this->btnSelDest = (gcnew System::Windows::Forms::Button());
			this->lblDestWidth = (gcnew System::Windows::Forms::Label());
			this->txtboxDestWidth = (gcnew System::Windows::Forms::TextBox());
			this->lblDestHeight = (gcnew System::Windows::Forms::Label());
			this->txtboxDestHeight = (gcnew System::Windows::Forms::TextBox());
			this->btnGo = (gcnew System::Windows::Forms::Button());
			this->dlgSelSrc = (gcnew System::Windows::Forms::FolderBrowserDialog());
			this->dlgSelDest = (gcnew System::Windows::Forms::FolderBrowserDialog());
			this->btnCancel = (gcnew System::Windows::Forms::Button());
			this->SuspendLayout();
			// 
			// listboxLog
			// 
			this->listboxLog->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) 
				| System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->listboxLog->FormattingEnabled = true;
			this->listboxLog->Location = System::Drawing::Point(12, 117);
			this->listboxLog->Name = L"listboxLog";
			this->listboxLog->Size = System::Drawing::Size(536, 290);
			this->listboxLog->TabIndex = 7;
			// 
			// lblSrc
			// 
			this->lblSrc->AutoSize = true;
			this->lblSrc->Location = System::Drawing::Point(12, 13);
			this->lblSrc->Name = L"lblSrc";
			this->lblSrc->Size = System::Drawing::Size(44, 13);
			this->lblSrc->TabIndex = 1;
			this->lblSrc->Text = L"Source:";
			// 
			// lblDest
			// 
			this->lblDest->AutoSize = true;
			this->lblDest->Location = System::Drawing::Point(12, 41);
			this->lblDest->Name = L"lblDest";
			this->lblDest->Size = System::Drawing::Size(63, 13);
			this->lblDest->TabIndex = 2;
			this->lblDest->Text = L"Destination:";
			// 
			// txtboxSrc
			// 
			this->txtboxSrc->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->txtboxSrc->HideSelection = false;
			this->txtboxSrc->Location = System::Drawing::Point(81, 10);
			this->txtboxSrc->Name = L"txtboxSrc";
			this->txtboxSrc->Size = System::Drawing::Size(386, 20);
			this->txtboxSrc->TabIndex = 0;
			this->txtboxSrc->Text = L"Y:\\Pictures";
			this->txtboxSrc->TextChanged += gcnew System::EventHandler(this, &Form1::txtboxSrc_TextChanged);
			// 
			// txtboxDest
			// 
			this->txtboxDest->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->txtboxDest->Location = System::Drawing::Point(81, 38);
			this->txtboxDest->Name = L"txtboxDest";
			this->txtboxDest->Size = System::Drawing::Size(386, 20);
			this->txtboxDest->TabIndex = 2;
			this->txtboxDest->Text = L"Z:\\lowres";
			this->txtboxDest->TextChanged += gcnew System::EventHandler(this, &Form1::txtboxDest_TextChanged);
			// 
			// btnSelSrc
			// 
			this->btnSelSrc->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->btnSelSrc->Location = System::Drawing::Point(473, 8);
			this->btnSelSrc->Name = L"btnSelSrc";
			this->btnSelSrc->Size = System::Drawing::Size(75, 23);
			this->btnSelSrc->TabIndex = 1;
			this->btnSelSrc->Text = L"Browse...";
			this->btnSelSrc->UseVisualStyleBackColor = true;
			this->btnSelSrc->Click += gcnew System::EventHandler(this, &Form1::btnSelSrc_Click);
			// 
			// btnSelDest
			// 
			this->btnSelDest->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->btnSelDest->Location = System::Drawing::Point(473, 36);
			this->btnSelDest->Name = L"btnSelDest";
			this->btnSelDest->Size = System::Drawing::Size(75, 23);
			this->btnSelDest->TabIndex = 3;
			this->btnSelDest->Text = L"Browse...";
			this->btnSelDest->UseVisualStyleBackColor = true;
			this->btnSelDest->Click += gcnew System::EventHandler(this, &Form1::btnSelDest_Click);
			// 
			// lblDestWidth
			// 
			this->lblDestWidth->AutoSize = true;
			this->lblDestWidth->Location = System::Drawing::Point(12, 68);
			this->lblDestWidth->Name = L"lblDestWidth";
			this->lblDestWidth->Size = System::Drawing::Size(38, 13);
			this->lblDestWidth->TabIndex = 7;
			this->lblDestWidth->Text = L"Width:";
			// 
			// txtboxDestWidth
			// 
			this->txtboxDestWidth->Location = System::Drawing::Point(81, 65);
			this->txtboxDestWidth->Name = L"txtboxDestWidth";
			this->txtboxDestWidth->Size = System::Drawing::Size(100, 20);
			this->txtboxDestWidth->TabIndex = 4;
			this->txtboxDestWidth->Text = L"300";
			// 
			// lblDestHeight
			// 
			this->lblDestHeight->AutoSize = true;
			this->lblDestHeight->Location = System::Drawing::Point(12, 94);
			this->lblDestHeight->Name = L"lblDestHeight";
			this->lblDestHeight->Size = System::Drawing::Size(41, 13);
			this->lblDestHeight->TabIndex = 9;
			this->lblDestHeight->Text = L"Height:";
			// 
			// txtboxDestHeight
			// 
			this->txtboxDestHeight->Location = System::Drawing::Point(81, 91);
			this->txtboxDestHeight->Name = L"txtboxDestHeight";
			this->txtboxDestHeight->Size = System::Drawing::Size(100, 20);
			this->txtboxDestHeight->TabIndex = 5;
			this->txtboxDestHeight->Text = L"300";
			// 
			// btnGo
			// 
			this->btnGo->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->btnGo->Location = System::Drawing::Point(473, 68);
			this->btnGo->Name = L"btnGo";
			this->btnGo->Size = System::Drawing::Size(75, 39);
			this->btnGo->TabIndex = 6;
			this->btnGo->Text = L"Go!";
			this->btnGo->UseVisualStyleBackColor = true;
			this->btnGo->Click += gcnew System::EventHandler(this, &Form1::btnGo_Click);
			// 
			// btnCancel
			// 
			this->btnCancel->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->btnCancel->Enabled = false;
			this->btnCancel->Location = System::Drawing::Point(392, 68);
			this->btnCancel->Name = L"btnCancel";
			this->btnCancel->Size = System::Drawing::Size(75, 39);
			this->btnCancel->TabIndex = 10;
			this->btnCancel->Text = L"Cancel";
			this->btnCancel->UseVisualStyleBackColor = true;
			this->btnCancel->Click += gcnew System::EventHandler(this, &Form1::btnCancel_Click);
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(560, 418);
			this->Controls->Add(this->btnCancel);
			this->Controls->Add(this->btnGo);
			this->Controls->Add(this->txtboxDestHeight);
			this->Controls->Add(this->lblDestHeight);
			this->Controls->Add(this->txtboxDestWidth);
			this->Controls->Add(this->lblDestWidth);
			this->Controls->Add(this->btnSelDest);
			this->Controls->Add(this->btnSelSrc);
			this->Controls->Add(this->txtboxDest);
			this->Controls->Add(this->txtboxSrc);
			this->Controls->Add(this->lblDest);
			this->Controls->Add(this->lblSrc);
			this->Controls->Add(this->listboxLog);
			this->Name = L"Form1";
			this->Text = L"Image Shrinker";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		SyncBuffer ^ filelist;
		Thread ^ worker;
		bool bWorkerRunning;
		System::Void btnSelSrc_Click(System::Object^  sender, System::EventArgs^  e);
		System::Void btnSelDest_Click(System::Object^  sender, System::EventArgs^  e);
		System::Void btnGo_Click(System::Object^  sender, System::EventArgs^  e);
		void WorkerThreadStart (Object ^ sParams);
		void ProcessDirectory (System::IO::DirectoryInfo ^ dirinfo, CWorkerThreadStartInfo ^ params);
		void ProcessFile (System::IO::FileInfo ^ file, String ^ newFilePath, CWorkerThreadStartInfo ^ params);
		System::Void txtboxSrc_TextChanged(System::Object^  sender, System::EventArgs^  e);
		System::Void txtboxDest_TextChanged(System::Object^  sender, System::EventArgs^  e);
		bool ThumbnailAbort ();
		void ClearLog ();
		void AddLogMsg (String ^ msg);
		void WorkerStarted ();
		void WorkerStopped ();
		void UpdateUI ();
		System::Void btnCancel_Click(System::Object^  sender, System::EventArgs^  e);
	};
}

