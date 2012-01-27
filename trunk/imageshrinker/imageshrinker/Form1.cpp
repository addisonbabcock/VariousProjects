#include "StdAfx.h"

using namespace imageshrinker;


System::Void Form1::btnSelSrc_Click(System::Object^  sender, System::EventArgs^  e)
{
	this->dlgSelSrc->SelectedPath = this->txtboxSrc->Text;
	if (this->dlgSelSrc->ShowDialog () == Windows::Forms::DialogResult::OK)
	{
		this->txtboxSrc->Text = this->dlgSelSrc->SelectedPath;
	}
	else
	{
		this->dlgSelSrc->SelectedPath = this->txtboxSrc->Text;
	}
}

System::Void Form1::btnSelDest_Click(System::Object^  sender, System::EventArgs^  e)
{
	this->dlgSelDest->SelectedPath = this->txtboxDest->Text;
	if (this->dlgSelDest->ShowDialog () == Windows::Forms::DialogResult::OK)
	{
		this->txtboxDest->Text = this->dlgSelDest->SelectedPath;
	}
	else
	{
		this->dlgSelDest->SelectedPath = this->txtboxDest->Text;
	}
}

System::Void Form1::btnGo_Click(System::Object^  sender, System::EventArgs^  e)
{
	filelist = gcnew SyncBuffer;
	CWorkerThreadStartInfo ^ cWorkerParams = gcnew CWorkerThreadStartInfo;

	try
	{
		cWorkerParams->iH = Convert::ToInt32 (this->txtboxDestHeight->Text);
		cWorkerParams->iW = Convert::ToInt32 (this->txtboxDestWidth->Text);
		if (cWorkerParams->iH <= 0 || cWorkerParams->iW <= 0)
			throw 5;
	}
	catch (...)
	{
		MessageBox::Show ("Height and width must be positive integers", "Error!");
		return;
	}
	cWorkerParams->sDest = this->txtboxDest->Text;
	cWorkerParams->sSrc = this->txtboxSrc->Text;

	worker = gcnew Thread (gcnew ParameterizedThreadStart (this, &Form1::WorkerThreadStart));
	worker->IsBackground = true;
	worker->Start (cWorkerParams);
}

void Form1::WorkerThreadStart (Object ^ params)
{
	WorkerStarted ();
	CWorkerThreadStartInfo ^ CWorkerParams = (CWorkerThreadStartInfo ^)(params);
	DirectoryInfo ^ dir = gcnew DirectoryInfo (CWorkerParams->sSrc);
	ClearLog ();
	AddLogMsg ("Starting processing on " + txtboxSrc->Text);
	ProcessDirectory (dir, CWorkerParams);
	delete dir;
//	dir = 0;
	WorkerStopped ();
}

void Form1::ProcessDirectory (DirectoryInfo ^ dir, CWorkerThreadStartInfo ^ params)
{
	AddLogMsg ("Processing " + dir->FullName);
	array <DirectoryInfo ^> ^ subDirs;
	try
	{
		subDirs = dir->GetDirectories ();
	}
	catch (DirectoryNotFoundException ^)
	{
		AddLogMsg ("Directory not found! " + dir->FullName);
		return;
	}

	int i = 0, j = 0;;
	for (i = 0; i < subDirs->Length; ++i)
	{
		ProcessDirectory (subDirs [i], params);
		delete subDirs [i];
	}

	String ^ lookfor = gcnew String ("*.gif;*.jpg;*.jpeg;*.png;*.bmp");
	array <String ^> ^ extensions = lookfor->Split (gcnew array <wchar_t> {';'});
	ArrayList ^ files = gcnew ArrayList;
	for (i = 0; i < extensions->Length; ++i)
	{
		files->AddRange (dir->GetFiles ("*.jpg", SearchOption::TopDirectoryOnly));
		delete extensions [i];
	}
	
	String ^ newFilePath = gcnew String (dir->FullName);
	newFilePath = newFilePath->Remove (0, params->sSrc->Length);
	newFilePath = newFilePath->Insert (0, params->sDest);
	DirectoryInfo ^ newDir = gcnew DirectoryInfo (newFilePath);
	if (!newDir->Exists)
		newDir->Create ();

	for (i = 0; i < files->Count; ++i)
	{
		ProcessFile ((FileInfo^)files [i], newFilePath, params);
	}

	delete newFilePath;
	delete files;
	delete lookfor;
	delete newDir;
	delete subDirs;
	delete extensions;
}

void Form1::ProcessFile (FileInfo ^ file, String ^ newFilePath, CWorkerThreadStartInfo ^ params)
{
	AddLogMsg ("Processing " + file->FullName);
	String ^ newFile = gcnew String (newFilePath + "\\" + file->Name);
	AddLogMsg ("Saving to " + newFile);

	FileInfo ^ newFileInfo = gcnew FileInfo (newFile);
//	if (!newFileInfo->Exists)
//		newFileInfo->Create ();
	FileStream ^ out = newFileInfo->OpenWrite ();

	Image ^ pic = Image::FromFile (file->FullName);
	Image ^ thumb = pic->GetThumbnailImage (
		params->iW,
		params->iH,
		gcnew Image::GetThumbnailImageAbort (this, &Form1::ThumbnailAbort),// IntPtr::Zero),
		IntPtr::Zero);

	try
	{
		thumb->Save (out, System::Drawing::Imaging::ImageFormat::Jpeg);
		out->Close ();
	}
	catch (...)
	{
		AddLogMsg ("Failed to save file: " + newFile);
	}
	delete newFileInfo;
	delete newFile;
	delete out;
	delete pic;
	delete thumb;
}

System::Void Form1::txtboxSrc_TextChanged(System::Object^  sender, System::EventArgs^  e)
{
	this->dlgSelSrc->SelectedPath = this->txtboxSrc->Text;
}

System::Void Form1::txtboxDest_TextChanged(System::Object^  sender, System::EventArgs^  e)
{
	this->dlgSelDest->SelectedPath = this->txtboxDest->Text;
}

bool Form1::ThumbnailAbort ()
{
	return false;
}

void Form1::ClearLog ()
{
	if (this->listboxLog->InvokeRequired)
	{
		Invoke (gcnew delVoidVoid (this, &Form1::ClearLog));
	}
	else
	{
		this->listboxLog->Items->Clear ();
	}
}

void Form1::AddLogMsg (String ^ msg)
{
	if (this->listboxLog->InvokeRequired)
	{
		Invoke (gcnew delVoidString (this, &Form1::AddLogMsg), msg);
	}
	else
	{
		this->listboxLog->Items->Add (msg);
		this->listboxLog->SelectedIndex = this->listboxLog->Items->Count - 1;
	}
}

void Form1::WorkerStarted ()
{
	if (this->listboxLog->InvokeRequired)
	{
		Invoke (gcnew delVoidVoid (this, &Form1::WorkerStarted));
	}
	else
	{
		bWorkerRunning = true;
		UpdateUI ();
	}
}

void Form1::WorkerStopped ()
{
	if (this->listboxLog->InvokeRequired)
	{
		Invoke (gcnew delVoidVoid (this, &Form1::WorkerStopped));
	}
	else
	{
		bWorkerRunning = false;
		UpdateUI ();
	}
}

void Form1::UpdateUI ()
{
	if (bWorkerRunning)
	{
		this->txtboxDest->Enabled = false;
		this->txtboxSrc->Enabled = false;
		this->txtboxDestHeight->Enabled = false;
		this->txtboxDestWidth->Enabled = false;
		this->btnCancel->Enabled = true;
		this->btnGo->Enabled = false;
	}
	else
	{
		this->txtboxDest->Enabled = true;
		this->txtboxSrc->Enabled = true;
		this->txtboxDestHeight->Enabled = true;
		this->txtboxDestWidth->Enabled = true;
		this->btnCancel->Enabled = false;
		this->btnGo->Enabled = true;
	}
}

System::Void Form1::btnCancel_Click(System::Object^  sender, System::EventArgs^  e)
{
	worker->Abort ();
	bWorkerRunning = false;
	UpdateUI ();
}
