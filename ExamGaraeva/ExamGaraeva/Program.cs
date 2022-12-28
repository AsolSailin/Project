using ExamGaraeva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft;

namespace WarCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            var harvester = new Harvester("Harvester", 1);
            var maner = new Miner("Miner", 2);
            var soldier = new Soldier("Soldier", 3);
            var tank = new Tank("Tank", 4);
            var volcanoTank = new VolcanoTank("VolcanoTank", 5);
            var worker = new Worker("Worker", 6);
        }
    }
}
