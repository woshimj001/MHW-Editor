﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MHW_Weapon_Editor.Armors;
using MHW_Weapon_Editor.Gems;
using MHW_Weapon_Editor.Weapons;
using Microsoft.Win32;

namespace MHW_Weapon_Editor {
    public partial class MainWindow {
        private readonly List<dynamic> items = new List<dynamic>();
        private string targetFile;

        public MainWindow() {
            InitializeComponent();

            dg_items.AutoGeneratingColumn += Dg_items_AutoGeneratingColumn;
            dg_items.AutoGeneratedColumns += Dg_items_AutoGeneratedColumns;

            btn_open.Click += Btn_open_Click;
            btn_save.Click += Btn_save_Click;
            btn_slot_hack.Click += Btn_slot_hack_Click;
            btn_gem_hack.Click += Btn_gem_hack_Click;
        }

        private void Dg_items_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.PropertyName) {
                case nameof(IMhwItem.Bytes):
                case nameof(IMhwItem.Changed):
                    e.Cancel = true;
                    break;
            }
        }

        private void Dg_items_AutoGeneratedColumns(object sender, System.EventArgs e) {
            dg_items.Columns.First(x => x.Header.ToString() == nameof(IMhwItem.Name)).DisplayIndex = 0;
        }

        private void Btn_open_Click(object sender, RoutedEventArgs e) {
            Open();
            if (string.IsNullOrEmpty(targetFile)) return;
            Load();

            dg_items.ItemsSource = null;
            dg_items.ItemsSource = items;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;
            Save();
        }

        private void Btn_slot_hack_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!IsMelee() && !IsRanged() && !IsArmor()) return;

            foreach (var item in items) {
                ISlots itemWithSlots = item;
                itemWithSlots.Slots = 3;
                itemWithSlots.Slot1Size = 3;
                itemWithSlots.Slot2Size = 3;
                itemWithSlots.Slot3Size = 3;

                if (item is Armor) {
                    Armor armor = item;
                    if (armor.Skill1 > 0) {
                        armor.Skill1Lvl = 10;
                    }
                    if (armor.Skill2 > 0) {
                        armor.Skill2Lvl = 10;
                    }
                    if (armor.Skill3 > 0) {
                        armor.Skill3Lvl = 10;
                    }
                }

                ((dynamic) itemWithSlots).OnPropertyChanged();
            }
        }

        private void Btn_gem_hack_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(targetFile)) return;

            if (!IsGem()) return;

            foreach (var item in items) {
                Gem gem = item;
                gem.SkillLevel = 10;
                ((dynamic) gem).OnPropertyChanged();
            }
        }

        private void Open() {
            var ofdResult = new OpenFileDialog() {
                // ReSharper disable StringLiteralTypo
                Filter = "Weapons / Armor / Gems (*.wp_dat/*.am_dat/_g, *.sgpa)|*.wp_dat;*.wp_dat_g;*.am_dat;*.sgpa",
                Multiselect = false
            };
            ofdResult.ShowDialog();

            targetFile = ofdResult.FileName;
        }

        private void Load() {
            items.Clear();

            int initialOffset;
            int itemSize;
            int itemBetweenOffset;

            if (IsMelee()) {
                initialOffset = Melee.WEAPON_OFFSET_INITIAL;
                itemSize = Melee.WEAPON_SIZE;
                itemBetweenOffset = Melee.WEAPON_OFFSET_BETWEEN;
            } else if (IsRanged()) {
                initialOffset = Ranged.WEAPON_OFFSET_INITIAL;
                itemSize = Ranged.WEAPON_SIZE;
                itemBetweenOffset = Ranged.WEAPON_OFFSET_BETWEEN;
            } else if (IsArmor()) {
                initialOffset = Armor.ARMOR_OFFSET_INITIAL;
                itemSize = Armor.ARMOR_SIZE;
                itemBetweenOffset = Armor.ARMOR_OFFSET_BETWEEN;
            } else if (IsGem()) {
                initialOffset = Gem.GEM_OFFSET_INITIAL;
                itemSize = Gem.GEM_SIZE;
                itemBetweenOffset = Gem.GEM_OFFSET_BETWEEN;
            } else {
                return;
            }

            using (var wpDat = new BinaryReader(new FileStream(targetFile, FileMode.Open, FileAccess.Read))) {
                var len = wpDat.BaseStream.Length;
                var offset = initialOffset;

                do {
                    var buff = new byte[itemSize];
                    wpDat.BaseStream.Seek(offset, SeekOrigin.Begin);
                    wpDat.Read(buff, 0, itemSize);

                    dynamic obj;

                    if (IsMelee()) {
                        obj = new Melee(buff, offset);
                    } else if (IsRanged()) {
                        obj = new Ranged(buff, offset);
                    } else if (IsArmor()) {
                        obj = new Armor(buff, offset);
                    } else if (IsGem()) {
                        obj = new Gem(buff, offset);
                    } else {
                        return;
                    }

                    items.Add(obj);

                    offset += itemBetweenOffset;
                } while (offset + itemSize <= len);
            }
        }

        private void Save() {
            using (var wpDat = new BinaryWriter(new FileStream(targetFile, FileMode.Open, FileAccess.Write))) {
                foreach (var item in items) {
                    IMhwItem obj = item;
                    // First starts at 25, so should be safe.
                    if (obj.Offset == 0 || !obj.Changed) continue;

                    var buff = obj.Bytes;

                    wpDat.Seek(obj.Offset, SeekOrigin.Begin);
                    wpDat.Write(buff);
                }
            }
        }

        private bool IsMelee() => Path.GetExtension(targetFile) == ".wp_dat";
        private bool IsRanged() => Path.GetExtension(targetFile) == ".wp_dat_g";
        private bool IsArmor() => Path.GetExtension(targetFile) == ".am_dat";
        private bool IsGem() => Path.GetExtension(targetFile) == ".sgpa";
    }
}