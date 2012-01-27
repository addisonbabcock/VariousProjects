#pragma once
#include <fstream>
#include <iostream>

namespace uptimealizer {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

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
			mbPrevAttemptSuccess = false;
			mbFirstRun = true;
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
	private: System::Windows::Forms::ListBox^  log;
	protected: 
	private: System::Windows::Forms::Label^  label1;

	private: System::Windows::Forms::OpenFileDialog^  dlgopen;
	private: System::Windows::Forms::Timer^  timer;
	private: System::Windows::Forms::Label^  lblstatus;
	private: System::Windows::Forms::CheckBox^  chkspammode;

	private: System::ComponentModel::IContainer^  components;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			this->log = (gcnew System::Windows::Forms::ListBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->dlgopen = (gcnew System::Windows::Forms::OpenFileDialog());
			this->timer = (gcnew System::Windows::Forms::Timer(this->components));
			this->lblstatus = (gcnew System::Windows::Forms::Label());
			this->chkspammode = (gcnew System::Windows::Forms::CheckBox());
			this->SuspendLayout();
			// 
			// log
			// 
			this->log->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) 
				| System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->log->FormattingEnabled = true;
			this->log->Location = System::Drawing::Point(12, 37);
			this->log->Name = L"log";
			this->log->Size = System::Drawing::Size(532, 433);
			this->log->TabIndex = 0;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 13);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(81, 13);
			this->label1->TabIndex = 1;
			this->label1->Text = L"Up / Down Log";
			// 
			// timer
			// 
			this->timer->Enabled = true;
			this->timer->Interval = 150000;
			this->timer->Tick += gcnew System::EventHandler(this, &Form1::timer_Tick);
			// 
			// lblstatus
			// 
			this->lblstatus->AutoSize = true;
			this->lblstatus->Location = System::Drawing::Point(147, 13);
			this->lblstatus->Name = L"lblstatus";
			this->lblstatus->Size = System::Drawing::Size(40, 13);
			this->lblstatus->TabIndex = 3;
			this->lblstatus->Text = L"Status:";
			// 
			// chkspammode
			// 
			this->chkspammode->AutoSize = true;
			this->chkspammode->Location = System::Drawing::Point(334, 12);
			this->chkspammode->Name = L"chkspammode";
			this->chkspammode->Size = System::Drawing::Size(82, 17);
			this->chkspammode->TabIndex = 4;
			this->chkspammode->Text = L"Spam mode";
			this->chkspammode->UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(556, 491);
			this->Controls->Add(this->chkspammode);
			this->Controls->Add(this->lblstatus);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->log);
			this->Name = L"Form1";
			this->Text = L"Uptimealizer 1.0";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
		System::Void btnload_Click(System::Object^  sender, System::EventArgs^  e) 
		{
			//array <unsigned char> ^ fstr = gcnew array <unsigned char> (100000);
			//int start (0);
			//int end (0);
			//dlgopen->InitialDirectory = "";
			//dlgopen->ShowDialog ();
			//System::IO::FileStream ^ f = gcnew System::IO::FileStream (dlgopen->FileName, System::IO::FileMode::Open);
			//f->Read (fstr, 0, 100000);
			//String ^ string = gcnew String;
			//for (int i = 0; i < fstr->Length; ++i)
			//{
			//}
			//log->Items->Add ();
			//f->Close ();
		}
		bool mbPrevAttemptSuccess;
		bool mbFirstRun;
		System::Void timer_Tick(System::Object^  sender, System::EventArgs^  e) 
		{
			using namespace System::Net;
			using namespace System::Net::Sockets;

			bool bSuccesful = true;

			lblstatus->ForeColor = Color::Yellow;
			lblstatus->Text = "Connecting";

			try
			{
				Socket ^ pinger = gcnew Socket (AddressFamily::InterNetwork,
					SocketType::Stream, ProtocolType::Tcp);
				pinger->Connect ("www.google.com", 80);
				pinger->Close ();
			}
			catch (...)
			{
				bSuccesful = false;
			}

			if (mbPrevAttemptSuccess != bSuccesful || mbFirstRun)
			{
				if (bSuccesful)
				{
					log->Items->Add ("Connection up " + 
						System::DateTime::Now.ToLongDateString () + " " + 
						System::DateTime::Now.ToLongTimeString ());
				}
				else
				{
					log->Items->Add ("Connection down " + 
						System::DateTime::Now.ToLongDateString () + " " + 
						System::DateTime::Now.ToLongTimeString ());
				}
			}
			if (bSuccesful)
			{
				lblstatus->ForeColor = Color::Green;
				lblstatus->Text = "Connected!";
			}
			else
			{
				lblstatus->ForeColor = Color::Red;
				lblstatus->Text = "Disconnected!";
				if (this->chkspammode->Checked)
					system ("net send * \"BIG BROTHER IS WATCHING YOU.\"");
			}

			mbPrevAttemptSuccess = bSuccesful;
			mbFirstRun = false;
		}
	};
}

