﻿namespace Nine.Graphics.Content
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Nine.Hosting;

    public class ContentProvider : IContentProvider
    {
        private readonly Lazy<HttpClient> http;
        private readonly ISharedMemory sharedMemory;

        public ContentProvider(ISharedMemory sharedMemory = null, HttpMessageHandler messageHandler = null)
        {
            this.sharedMemory = sharedMemory;
            this.http = new Lazy<HttpClient>(() => new HttpClient(messageHandler ?? new HttpClientHandler()));
        }

        public async Task<Stream> Open(string name)
        {
            if (name.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                name.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                var response = await http.Value.GetAsync(name).ConfigureAwait(false);
                var content = response.EnsureSuccessStatusCode().Content;
                return await content.ReadAsStreamAsync().ConfigureAwait(false);
            }

            if (!File.Exists(name)) return null;
            return File.OpenRead(name);
        }
    }
}
