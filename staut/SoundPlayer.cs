using System;
using System.IO;
using System.Media;

namespace Staut {
    public class SoundService {
        private readonly SoundPlayer? _player;

        public SoundService(string relativePath) {
            try {
                string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

                if (File.Exists(fullPath)) {
                    _player = new SoundPlayer(fullPath);
                    _player.Load();
                } else {
                    Console.WriteLine($"Filepath not found: {fullPath}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error loading sound file: {ex.Message}");
            }
        }

        public void Play() {
            _player?.Play();
        }

        public void PlaySync() {
            _player?.PlaySync();
        }

        public void Stop() {
            _player?.Stop();
        }
    }
}