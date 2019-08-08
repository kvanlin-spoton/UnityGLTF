﻿using System.IO;
using System;
using System.Threading.Tasks;

namespace UnityGLTF.Loader
{
	public class FileLoader : ILoader
	{
		private string _rootDirectoryPath;
		public Stream LoadedStream { get; private set; }

		public bool HasSyncLoadMethod { get; private set; }

		public FileLoader(string rootDirectoryPath)
		{
			_rootDirectoryPath = rootDirectoryPath;
			HasSyncLoadMethod = true;
		}

#pragma warning disable 1998
		public async Task LoadStream(string gltfFilePath)
#pragma warning restore 1998
		{
			if (gltfFilePath == null)
			{
				throw new ArgumentNullException("gltfFilePath");
			}

			string pathToLoad = Path.Combine(_rootDirectoryPath, gltfFilePath);
			if (!File.Exists(pathToLoad))
			{
				throw new FileNotFoundException("Buffer file not found", gltfFilePath);
			}

			LoadedStream = File.OpenRead(pathToLoad);
		}

		public void LoadStreamSync(string gltfFilePath)
		{
			if (gltfFilePath == null)
			{
				throw new ArgumentNullException("gltfFilePath");
			}

			LoadFileStreamSync(_rootDirectoryPath, gltfFilePath);
		}

		private void LoadFileStreamSync(string rootPath, string fileToLoad)
		{
			string pathToLoad = Path.Combine(rootPath, fileToLoad);
			if (!File.Exists(pathToLoad))
			{
				throw new FileNotFoundException("Buffer file not found", fileToLoad);
			}

			LoadedStream = File.OpenRead(pathToLoad);
		}
	}
}
