﻿// <copyright file="Gates.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.Initialization
{
    using System.Collections.Generic;
    using System.Linq;

    using MUnique.OpenMU.DataModel.Configuration;

    /// <summary>
    /// Gates initialization.
    /// </summary>
    public class Gates
    {
        private IRepositoryManager repositoryManager;

        /// <summary>
        /// Initializes the gates.
        /// </summary>
        /// <param name="repositoryManager">The repository manager. It should contain a filled game map repository.</param>
        /// <param name="gameConfiguration">The game configuration.</param>
        public void Initialize(IRepositoryManager repositoryManager, GameConfiguration gameConfiguration)
        {
            this.repositoryManager = repositoryManager;
            var maps = gameConfiguration.Maps.ToDictionary(map => map.Number, map => map);
            var targetGates = this.CreateTargetGates(maps);
            this.CreateEnterGates(maps, targetGates);
        }

        private ExitGate CreateExitGate(GameMapDefinition map, byte x1, byte y1, byte x2, byte y2, byte direction)
        {
            var gate = this.repositoryManager.CreateNew<ExitGate>();
            gate.Map = map;
            gate.X1 = x1;
            gate.Y1 = y1;
            gate.X2 = x2;
            gate.Y2 = y2;
            gate.Direction = (Direction)direction;
            return gate;
        }

        /// <summary>
        /// Creates the target gates and adds them to the <see cref="GameMapDefinition.SpawnGates" /> if the gate is specified as spawn gate (flag == 0).
        /// </summary>
        /// <param name="maps">The previously created game maps.</param>
        /// <returns>A dictionary of all created exit gates. The key is the number.</returns>
        /// <remarks>
        /// Regex #1: (?m)^(\d+)\s+?(0)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+).*?$
        /// Replace by #1: targetGates.Add\($1, new ExitGate { Map = maps[$3], X1 = $4, Y1 = $5, X2 = $6, Y2 = $7, Direction = $9 }\);\r\nmaps[$3].SpawnGates.Add\(targetGates[$1]\);
        /// Regex #2: (?m)^(\d+)\s+?(2)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+).*?$
        /// Replace by #2: targetGates.Add\($1, new ExitGate { Map = maps[$3], X1 = $4, Y1 = $5, X2 = $6, Y2 = $7, Direction = $9 }\);
        /// Rplace by #2.1: targetGates.Add($1, this.CreateExitGate(maps[$3], $4, $5, $6, $7, $9));
        /// </remarks>
        private IDictionary<short, ExitGate> CreateTargetGates(IDictionary<short, GameMapDefinition> maps)
        {
            var targetGates = new Dictionary<short, ExitGate>();
            targetGates.Add(17, this.CreateExitGate(maps[0], 133, 118, 151, 135, 0));
            maps[0].SpawnGates.Add(targetGates[17]);
            targetGates.Add(22, this.CreateExitGate(maps[2], 197, 35, 218, 50, 0));
            maps[2].SpawnGates.Add(targetGates[22]);
            targetGates.Add(27, this.CreateExitGate(maps[3], 171, 108, 177, 117, 0));
            maps[3].SpawnGates.Add(targetGates[27]);
            targetGates.Add(42, this.CreateExitGate(maps[4], 203, 70, 213, 81, 0));
            maps[4].SpawnGates.Add(targetGates[42]);
            targetGates.Add(49, this.CreateExitGate(maps[7], 15, 11, 27, 23, 0));
            maps[7].SpawnGates.Add(targetGates[49]);
            targetGates.Add(50, this.CreateExitGate(maps[6], 72, 140, 73, 181, 0));
            maps[6].SpawnGates.Add(targetGates[50]);
            targetGates.Add(51, this.CreateExitGate(maps[6], 59, 153, 59, 153, 0));
            maps[6].SpawnGates.Add(targetGates[51]);
            targetGates.Add(52, this.CreateExitGate(maps[6], 59, 164, 59, 165, 0));
            maps[6].SpawnGates.Add(targetGates[52]);
            targetGates.Add(57, this.CreateExitGate(maps[8], 187, 54, 203, 69, 0));
            maps[8].SpawnGates.Add(targetGates[57]);
            targetGates.Add(58, this.CreateExitGate(maps[9], 133, 91, 141, 99, 0));
            maps[9].SpawnGates.Add(targetGates[58]);
            targetGates.Add(59, this.CreateExitGate(maps[9], 135, 162, 142, 170, 0));
            maps[9].SpawnGates.Add(targetGates[59]);
            targetGates.Add(60, this.CreateExitGate(maps[9], 62, 150, 70, 158, 0));
            maps[9].SpawnGates.Add(targetGates[60]);
            targetGates.Add(61, this.CreateExitGate(maps[9], 66, 84, 74, 92, 0));
            maps[9].SpawnGates.Add(targetGates[61]);
            targetGates.Add(66, this.CreateExitGate(maps[11], 12, 5, 14, 10, 0));
            maps[11].SpawnGates.Add(targetGates[66]);
            targetGates.Add(67, this.CreateExitGate(maps[12], 12, 5, 14, 10, 0));
            maps[12].SpawnGates.Add(targetGates[67]);
            targetGates.Add(68, this.CreateExitGate(maps[13], 12, 5, 14, 10, 0));
            maps[13].SpawnGates.Add(targetGates[68]);
            targetGates.Add(69, this.CreateExitGate(maps[14], 12, 5, 14, 10, 0));
            maps[14].SpawnGates.Add(targetGates[69]);
            targetGates.Add(70, this.CreateExitGate(maps[15], 12, 5, 14, 10, 0));
            maps[15].SpawnGates.Add(targetGates[70]);
            targetGates.Add(71, this.CreateExitGate(maps[16], 12, 5, 14, 10, 0));
            maps[16].SpawnGates.Add(targetGates[71]);
            targetGates.Add(72, this.CreateExitGate(maps[2], 23, 27, 27, 24, 0));
            maps[2].SpawnGates.Add(targetGates[72]);
            targetGates.Add(73, this.CreateExitGate(maps[2], 224, 231, 227, 227, 0));
            maps[2].SpawnGates.Add(targetGates[73]);
            targetGates.Add(74, this.CreateExitGate(maps[2], 69, 181, 72, 178, 0));
            maps[2].SpawnGates.Add(targetGates[74]);
            targetGates.Add(75, this.CreateExitGate(maps[7], 225, 53, 228, 50, 0));
            maps[7].SpawnGates.Add(targetGates[75]);
            targetGates.Add(76, this.CreateExitGate(maps[7], 62, 163, 68, 157, 0));
            maps[7].SpawnGates.Add(targetGates[76]);
            targetGates.Add(77, this.CreateExitGate(maps[8], 96, 143, 100, 146, 0));
            maps[8].SpawnGates.Add(targetGates[77]);
            targetGates.Add(80, this.CreateExitGate(maps[17], 12, 5, 14, 10, 0));
            maps[17].SpawnGates.Add(targetGates[80]);
            targetGates.Add(82, this.CreateExitGate(maps[18], 31, 88, 36, 95, 0));
            maps[18].SpawnGates.Add(targetGates[82]);
            targetGates.Add(83, this.CreateExitGate(maps[19], 31, 88, 36, 95, 0));
            maps[19].SpawnGates.Add(targetGates[83]);
            targetGates.Add(84, this.CreateExitGate(maps[20], 31, 88, 36, 95, 0));
            maps[20].SpawnGates.Add(targetGates[84]);
            targetGates.Add(85, this.CreateExitGate(maps[21], 31, 88, 36, 95, 0));
            maps[21].SpawnGates.Add(targetGates[85]);
            targetGates.Add(86, this.CreateExitGate(maps[22], 31, 88, 36, 95, 0));
            maps[22].SpawnGates.Add(targetGates[86]);
            targetGates.Add(87, this.CreateExitGate(maps[23], 31, 88, 36, 95, 0));
            maps[23].SpawnGates.Add(targetGates[87]);
            targetGates.Add(88, this.CreateExitGate(maps[24], 10, 16, 17, 22, 0));
            maps[24].SpawnGates.Add(targetGates[88]);
            targetGates.Add(89, this.CreateExitGate(maps[25], 10, 16, 17, 22, 0));
            maps[25].SpawnGates.Add(targetGates[89]);
            targetGates.Add(90, this.CreateExitGate(maps[26], 10, 16, 17, 22, 0));
            maps[26].SpawnGates.Add(targetGates[90]);
            targetGates.Add(91, this.CreateExitGate(maps[27], 10, 16, 17, 22, 0));
            maps[27].SpawnGates.Add(targetGates[91]);
            targetGates.Add(92, this.CreateExitGate(maps[28], 10, 16, 17, 22, 0));
            maps[28].SpawnGates.Add(targetGates[92]);
            targetGates.Add(93, this.CreateExitGate(maps[29], 10, 16, 17, 22, 0));
            maps[29].SpawnGates.Add(targetGates[93]);
            targetGates.Add(94, this.CreateExitGate(maps[30], 88, 31, 102, 46, 0));
            maps[30].SpawnGates.Add(targetGates[94]);
            targetGates.Add(95, this.CreateExitGate(maps[31], 60, 10, 69, 19, 0));
            maps[31].SpawnGates.Add(targetGates[95]);
            targetGates.Add(100, this.CreateExitGate(maps[30], 39, 14, 142, 50, 0));
            maps[30].SpawnGates.Add(targetGates[100]);
            targetGates.Add(101, this.CreateExitGate(maps[30], 84, 180, 100, 222, 0));
            maps[30].SpawnGates.Add(targetGates[101]);
            targetGates.Add(104, this.CreateExitGate(maps[30], 87, 209, 100, 232, 0));
            maps[30].SpawnGates.Add(targetGates[104]);
            targetGates.Add(105, this.CreateExitGate(maps[30], 72, 10, 104, 199, 0));
            maps[30].SpawnGates.Add(targetGates[105]);
            targetGates.Add(106, this.CreateExitGate(maps[30], 131, 94, 138, 92, 0));
            maps[30].SpawnGates.Add(targetGates[106]);
            targetGates.Add(111, this.CreateExitGate(maps[32], 133, 91, 141, 99, 0));
            maps[32].SpawnGates.Add(targetGates[111]);
            targetGates.Add(112, this.CreateExitGate(maps[32], 135, 162, 142, 170, 0));
            maps[32].SpawnGates.Add(targetGates[112]);
            targetGates.Add(116, this.CreateExitGate(maps[36], 10, 16, 17, 22, 0));
            maps[36].SpawnGates.Add(targetGates[116]);
            targetGates.Add(118, this.CreateExitGate(maps[34], 229, 37, 239, 46, 0));
            maps[34].SpawnGates.Add(targetGates[118]);
            targetGates.Add(119, this.CreateExitGate(maps[33], 82, 8, 87, 14, 0));
            maps[33].SpawnGates.Add(targetGates[119]);
            targetGates.Add(133, this.CreateExitGate(maps[39], 196, 56, 201, 57, 0));
            maps[39].SpawnGates.Add(targetGates[133]);
            targetGates.Add(134, this.CreateExitGate(maps[39], 78, 93, 82, 95, 0));
            maps[39].SpawnGates.Add(targetGates[134]);
            targetGates.Add(135, this.CreateExitGate(maps[39], 78, 93, 82, 95, 0));
            maps[39].SpawnGates.Add(targetGates[135]);
            targetGates.Add(136, this.CreateExitGate(maps[38], 137, 162, 143, 163, 0));
            maps[38].SpawnGates.Add(targetGates[136]);
            targetGates.Add(137, this.CreateExitGate(maps[38], 71, 104, 72, 107, 0));
            maps[38].SpawnGates.Add(targetGates[137]);
            targetGates.Add(138, this.CreateExitGate(maps[37], 19, 217, 21, 219, 0));
            maps[37].SpawnGates.Add(targetGates[138]);
            targetGates.Add(139, this.CreateExitGate(maps[38], 71, 104, 72, 107, 0));
            maps[38].SpawnGates.Add(targetGates[139]);
            targetGates.Add(140, this.CreateExitGate(maps[33], 186, 173, 190, 177, 0));
            maps[33].SpawnGates.Add(targetGates[140]);
            targetGates.Add(141, this.CreateExitGate(maps[37], 205, 36, 208, 41, 0));
            maps[37].SpawnGates.Add(targetGates[141]);
            targetGates.Add(142, this.CreateExitGate(maps[45], 98, 128, 108, 137, 0));
            maps[45].SpawnGates.Add(targetGates[142]);
            targetGates.Add(143, this.CreateExitGate(maps[46], 98, 128, 108, 137, 0));
            maps[46].SpawnGates.Add(targetGates[143]);
            targetGates.Add(144, this.CreateExitGate(maps[47], 98, 128, 108, 137, 0));
            maps[47].SpawnGates.Add(targetGates[144]);
            targetGates.Add(145, this.CreateExitGate(maps[48], 98, 128, 108, 137, 0));
            maps[48].SpawnGates.Add(targetGates[145]);
            targetGates.Add(146, this.CreateExitGate(maps[49], 98, 128, 108, 137, 0));
            maps[49].SpawnGates.Add(targetGates[146]);
            targetGates.Add(147, this.CreateExitGate(maps[50], 98, 128, 108, 137, 0));
            maps[50].SpawnGates.Add(targetGates[147]);
            targetGates.Add(148, this.CreateExitGate(maps[45], 141, 41, 146, 45, 0));
            maps[45].SpawnGates.Add(targetGates[148]);
            targetGates.Add(149, this.CreateExitGate(maps[46], 141, 41, 146, 45, 0));
            maps[46].SpawnGates.Add(targetGates[149]);
            targetGates.Add(150, this.CreateExitGate(maps[47], 141, 41, 146, 45, 0));
            maps[47].SpawnGates.Add(targetGates[150]);
            targetGates.Add(151, this.CreateExitGate(maps[48], 141, 41, 146, 45, 0));
            maps[48].SpawnGates.Add(targetGates[151]);
            targetGates.Add(152, this.CreateExitGate(maps[49], 141, 41, 146, 45, 0));
            maps[49].SpawnGates.Add(targetGates[152]);
            targetGates.Add(153, this.CreateExitGate(maps[50], 141, 41, 146, 45, 0));
            maps[50].SpawnGates.Add(targetGates[153]);
            targetGates.Add(154, this.CreateExitGate(maps[45], 194, 124, 198, 127, 0));
            maps[45].SpawnGates.Add(targetGates[154]);
            targetGates.Add(155, this.CreateExitGate(maps[46], 194, 124, 198, 127, 0));
            maps[46].SpawnGates.Add(targetGates[155]);
            targetGates.Add(156, this.CreateExitGate(maps[47], 194, 124, 198, 127, 0));
            maps[47].SpawnGates.Add(targetGates[156]);
            targetGates.Add(157, this.CreateExitGate(maps[48], 194, 124, 198, 127, 0));
            maps[48].SpawnGates.Add(targetGates[157]);
            targetGates.Add(158, this.CreateExitGate(maps[49], 194, 124, 198, 127, 0));
            maps[49].SpawnGates.Add(targetGates[158]);
            targetGates.Add(159, this.CreateExitGate(maps[50], 194, 124, 198, 127, 0));
            maps[50].SpawnGates.Add(targetGates[159]);
            targetGates.Add(256, this.CreateExitGate(maps[41], 29, 79, 31, 82, 0));
            maps[41].SpawnGates.Add(targetGates[256]);
            targetGates.Add(257, this.CreateExitGate(maps[42], 104, 178, 107, 181, 0));
            maps[42].SpawnGates.Add(targetGates[257]);
            targetGates.Add(258, this.CreateExitGate(maps[34], 227, 41, 229, 43, 0));
            maps[34].SpawnGates.Add(targetGates[258]);
            targetGates.Add(267, this.CreateExitGate(maps[51], 51, 224, 54, 227, 0));
            maps[51].SpawnGates.Add(targetGates[267]);
            targetGates.Add(268, this.CreateExitGate(maps[51], 99, 55, 100, 57, 0));
            maps[51].SpawnGates.Add(targetGates[268]);
            targetGates.Add(269, this.CreateExitGate(maps[51], 191, 148, 193, 150, 0));
            maps[51].SpawnGates.Add(targetGates[269]);
            targetGates.Add(270, this.CreateExitGate(maps[32], 62, 150, 70, 158, 0));
            maps[32].SpawnGates.Add(targetGates[270]);
            targetGates.Add(271, this.CreateExitGate(maps[52], 12, 5, 14, 10, 0));
            maps[52].SpawnGates.Add(targetGates[271]);
            targetGates.Add(272, this.CreateExitGate(maps[53], 31, 88, 36, 95, 0));
            maps[53].SpawnGates.Add(targetGates[272]);
            targetGates.Add(273, this.CreateExitGate(maps[56], 135, 105, 142, 111, 0));
            maps[56].SpawnGates.Add(targetGates[273]);
            targetGates.Add(287, this.CreateExitGate(maps[57], 222, 211, 225, 212, 0));
            maps[57].SpawnGates.Add(targetGates[287]);
            targetGates.Add(289, this.CreateExitGate(maps[2], 52, 88, 54, 89, 0));
            maps[2].SpawnGates.Add(targetGates[289]);
            targetGates.Add(291, this.CreateExitGate(maps[58], 160, 24, 161, 27, 0));
            maps[58].SpawnGates.Add(targetGates[291]);
            targetGates.Add(293, this.CreateExitGate(maps[57], 174, 23, 175, 25, 0));
            maps[57].SpawnGates.Add(targetGates[293]);
            targetGates.Add(294, this.CreateExitGate(maps[63], 120, 129, 126, 134, 0));
            maps[63].SpawnGates.Add(targetGates[294]);
            targetGates.Add(295, this.CreateExitGate(maps[64], 101, 64, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[295]);
            targetGates.Add(296, this.CreateExitGate(maps[64], 101, 75, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[296]);
            targetGates.Add(297, this.CreateExitGate(maps[64], 101, 113, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[297]);
            targetGates.Add(298, this.CreateExitGate(maps[64], 101, 124, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[298]);
            targetGates.Add(299, this.CreateExitGate(maps[64], 154, 64, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[299]);
            targetGates.Add(300, this.CreateExitGate(maps[64], 154, 75, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[300]);
            targetGates.Add(301, this.CreateExitGate(maps[64], 154, 113, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[301]);
            targetGates.Add(302, this.CreateExitGate(maps[64], 154, 124, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[302]);
            targetGates.Add(303, this.CreateExitGate(maps[64], 100, 70, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[303]);
            targetGates.Add(304, this.CreateExitGate(maps[64], 100, 120, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[304]);
            targetGates.Add(305, this.CreateExitGate(maps[64], 150, 70, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[305]);
            targetGates.Add(306, this.CreateExitGate(maps[64], 150, 120, 0, 0, 0));
            maps[64].SpawnGates.Add(targetGates[306]);
            targetGates.Add(307, this.CreateExitGate(maps[69], 231, 14, 233, 16, 0));
            maps[69].SpawnGates.Add(targetGates[307]);
            targetGates.Add(309, this.CreateExitGate(maps[69], 202, 24, 203, 27, 0));
            maps[69].SpawnGates.Add(targetGates[309]);
            targetGates.Add(311, this.CreateExitGate(maps[69], 179, 65, 181, 67, 0));
            maps[69].SpawnGates.Add(targetGates[311]);
            targetGates.Add(312, this.CreateExitGate(maps[70], 86, 66, 88, 68, 0));
            maps[70].SpawnGates.Add(targetGates[312]);
            targetGates.Add(314, this.CreateExitGate(maps[70], 36, 82, 38, 84, 0));
            maps[70].SpawnGates.Add(targetGates[314]);
            targetGates.Add(316, this.CreateExitGate(maps[70], 123, 110, 125, 112, 0));
            maps[70].SpawnGates.Add(targetGates[316]);
            targetGates.Add(317, this.CreateExitGate(maps[71], 154, 186, 155, 188, 0));
            maps[71].SpawnGates.Add(targetGates[317]);
            targetGates.Add(319, this.CreateExitGate(maps[71], 222, 121, 224, 123, 0));
            maps[71].SpawnGates.Add(targetGates[319]);
            targetGates.Add(321, this.CreateExitGate(maps[71], 166, 205, 168, 206, 0));
            maps[71].SpawnGates.Add(targetGates[321]);
            targetGates.Add(322, this.CreateExitGate(maps[72], 93, 67, 95, 69, 0));
            maps[72].SpawnGates.Add(targetGates[322]);
            targetGates.Add(324, this.CreateExitGate(maps[72], 32, 163, 34, 165, 0));
            maps[72].SpawnGates.Add(targetGates[324]);
            targetGates.Add(326, this.CreateExitGate(maps[72], 145, 155, 147, 157, 0));
            maps[72].SpawnGates.Add(targetGates[326]);
            targetGates.Add(328, this.CreateExitGate(maps[72], 241, 23, 243, 25, 0));
            maps[72].SpawnGates.Add(targetGates[328]);
            targetGates.Add(329, this.CreateExitGate(maps[65], 193, 26, 200, 32, 0));
            maps[65].SpawnGates.Add(targetGates[329]);
            targetGates.Add(330, this.CreateExitGate(maps[66], 133, 68, 139, 74, 0));
            maps[66].SpawnGates.Add(targetGates[330]);
            targetGates.Add(331, this.CreateExitGate(maps[67], 106, 58, 111, 62, 0));
            maps[67].SpawnGates.Add(targetGates[331]);
            targetGates.Add(332, this.CreateExitGate(maps[68], 90, 10, 97, 17, 0));
            maps[68].SpawnGates.Add(targetGates[332]);

            targetGates.Add(2, this.CreateExitGate(maps[1], 107, 247, 110, 247, 1));
            targetGates.Add(4, this.CreateExitGate(maps[0], 121, 231, 123, 231, 1));
            targetGates.Add(6, this.CreateExitGate(maps[1], 231, 126, 234, 127, 1));
            targetGates.Add(8, this.CreateExitGate(maps[1], 240, 148, 241, 151, 3));
            targetGates.Add(10, this.CreateExitGate(maps[1], 3, 83, 4, 86, 3));
            targetGates.Add(12, this.CreateExitGate(maps[1], 3, 16, 6, 17, 3));
            targetGates.Add(14, this.CreateExitGate(maps[1], 29, 125, 30, 126, 1));
            targetGates.Add(16, this.CreateExitGate(maps[1], 5, 32, 7, 33, 1));
            targetGates.Add(19, this.CreateExitGate(maps[2], 242, 34, 243, 37, 7));
            targetGates.Add(21, this.CreateExitGate(maps[0], 7, 38, 8, 41, 3));
            targetGates.Add(24, this.CreateExitGate(maps[3], 148, 5, 155, 6, 5));
            targetGates.Add(26, this.CreateExitGate(maps[0], 213, 244, 217, 245, 1));
            targetGates.Add(29, this.CreateExitGate(maps[4], 162, 2, 166, 3, 5));
            targetGates.Add(31, this.CreateExitGate(maps[4], 241, 237, 244, 238, 1));
            targetGates.Add(33, this.CreateExitGate(maps[4], 86, 166, 87, 168, 3));
            targetGates.Add(35, this.CreateExitGate(maps[4], 87, 86, 88, 89, 3));
            targetGates.Add(37, this.CreateExitGate(maps[4], 128, 53, 131, 54, 1));
            targetGates.Add(39, this.CreateExitGate(maps[4], 52, 53, 55, 54, 1));
            targetGates.Add(41, this.CreateExitGate(maps[4], 8, 85, 9, 87, 1));
            targetGates.Add(44, this.CreateExitGate(maps[2], 2, 246, 3, 247, 2));
            targetGates.Add(46, this.CreateExitGate(maps[7], 14, 12, 15, 13, 3));
            targetGates.Add(48, this.CreateExitGate(maps[3], 240, 240, 241, 243, 7));
            targetGates.Add(54, this.CreateExitGate(maps[8], 248, 40, 251, 44, 7));
            targetGates.Add(56, this.CreateExitGate(maps[7], 16, 225, 17, 230, 3));
            targetGates.Add(63, this.CreateExitGate(maps[10], 14, 13, 16, 13, 5));
            targetGates.Add(65, this.CreateExitGate(maps[4], 17, 249, 19, 249, 1));
            targetGates.Add(97, this.CreateExitGate(maps[30], 164, 198, 187, 209, 0));
            targetGates.Add(99, this.CreateExitGate(maps[30], 90, 236, 99, 239, 0));
            targetGates.Add(103, this.CreateExitGate(maps[30], 29, 42, 30, 37, 0));
            targetGates.Add(108, this.CreateExitGate(maps[0], 235, 13, 239, 13, 0));
            targetGates.Add(110, this.CreateExitGate(maps[30], 131, 94, 138, 92, 0));
            targetGates.Add(113, this.CreateExitGate(maps[33], 76, 9, 78, 16, 0));
            targetGates.Add(114, this.CreateExitGate(maps[34], 231, 37, 234, 45, 0));
            targetGates.Add(122, this.CreateExitGate(maps[3], 220, 31, 226, 34, 0));
            targetGates.Add(124, this.CreateExitGate(maps[30], 155, 37, 158, 43, 0));
            targetGates.Add(126, this.CreateExitGate(maps[37], 17, 219, 21, 220, 0));
            targetGates.Add(128, this.CreateExitGate(maps[8], 7, 199, 7, 201, 0));
            targetGates.Add(130, this.CreateExitGate(maps[38], 70, 104, 70, 107, 0));
            targetGates.Add(132, this.CreateExitGate(maps[37], 85, 89, 86, 92, 0));
            targetGates.Add(161, this.CreateExitGate(maps[45], 170, 101, 170, 103, 0));
            targetGates.Add(163, this.CreateExitGate(maps[45], 149, 84, 152, 84, 0));
            targetGates.Add(165, this.CreateExitGate(maps[45], 149, 122, 151, 122, 0));
            targetGates.Add(167, this.CreateExitGate(maps[45], 132, 99, 132, 103, 0));
            targetGates.Add(169, this.CreateExitGate(maps[45], 207, 65, 207, 68, 0));
            targetGates.Add(171, this.CreateExitGate(maps[45], 186, 47, 189, 47, 0));
            targetGates.Add(173, this.CreateExitGate(maps[45], 186, 84, 189, 84, 0));
            targetGates.Add(175, this.CreateExitGate(maps[45], 169, 65, 169, 68, 0));
            targetGates.Add(177, this.CreateExitGate(maps[46], 170, 101, 170, 103, 0));
            targetGates.Add(179, this.CreateExitGate(maps[46], 149, 84, 152, 84, 0));
            targetGates.Add(181, this.CreateExitGate(maps[46], 149, 122, 151, 122, 0));
            targetGates.Add(183, this.CreateExitGate(maps[46], 132, 99, 132, 103, 0));
            targetGates.Add(185, this.CreateExitGate(maps[46], 207, 65, 207, 68, 0));
            targetGates.Add(187, this.CreateExitGate(maps[46], 186, 47, 189, 47, 0));
            targetGates.Add(189, this.CreateExitGate(maps[46], 186, 84, 189, 84, 0));
            targetGates.Add(191, this.CreateExitGate(maps[46], 169, 65, 169, 68, 0));
            targetGates.Add(193, this.CreateExitGate(maps[47], 170, 101, 170, 103, 0));
            targetGates.Add(195, this.CreateExitGate(maps[47], 149, 84, 152, 84, 0));
            targetGates.Add(197, this.CreateExitGate(maps[47], 149, 122, 151, 122, 0));
            targetGates.Add(199, this.CreateExitGate(maps[47], 132, 99, 132, 103, 0));
            targetGates.Add(201, this.CreateExitGate(maps[47], 207, 65, 207, 68, 0));
            targetGates.Add(203, this.CreateExitGate(maps[47], 186, 47, 189, 47, 0));
            targetGates.Add(205, this.CreateExitGate(maps[47], 186, 84, 189, 84, 0));
            targetGates.Add(207, this.CreateExitGate(maps[47], 169, 65, 169, 68, 0));
            targetGates.Add(209, this.CreateExitGate(maps[48], 170, 101, 170, 103, 0));
            targetGates.Add(211, this.CreateExitGate(maps[48], 149, 84, 152, 84, 0));
            targetGates.Add(213, this.CreateExitGate(maps[48], 149, 122, 151, 122, 0));
            targetGates.Add(215, this.CreateExitGate(maps[48], 132, 99, 132, 103, 0));
            targetGates.Add(217, this.CreateExitGate(maps[48], 207, 65, 207, 68, 0));
            targetGates.Add(219, this.CreateExitGate(maps[48], 186, 47, 189, 47, 0));
            targetGates.Add(221, this.CreateExitGate(maps[48], 186, 84, 189, 84, 0));
            targetGates.Add(223, this.CreateExitGate(maps[48], 169, 65, 169, 68, 0));
            targetGates.Add(225, this.CreateExitGate(maps[49], 170, 101, 170, 103, 0));
            targetGates.Add(227, this.CreateExitGate(maps[49], 149, 84, 152, 84, 0));
            targetGates.Add(229, this.CreateExitGate(maps[49], 149, 122, 151, 122, 0));
            targetGates.Add(231, this.CreateExitGate(maps[49], 132, 99, 132, 103, 0));
            targetGates.Add(233, this.CreateExitGate(maps[49], 207, 65, 207, 68, 0));
            targetGates.Add(235, this.CreateExitGate(maps[49], 186, 47, 189, 47, 0));
            targetGates.Add(237, this.CreateExitGate(maps[49], 186, 84, 189, 84, 0));
            targetGates.Add(239, this.CreateExitGate(maps[49], 169, 65, 169, 68, 0));
            targetGates.Add(241, this.CreateExitGate(maps[50], 170, 101, 170, 103, 0));
            targetGates.Add(243, this.CreateExitGate(maps[50], 149, 84, 152, 84, 0));
            targetGates.Add(245, this.CreateExitGate(maps[50], 149, 122, 151, 122, 0));
            targetGates.Add(247, this.CreateExitGate(maps[50], 132, 99, 132, 103, 0));
            targetGates.Add(249, this.CreateExitGate(maps[50], 207, 65, 207, 68, 0));
            targetGates.Add(251, this.CreateExitGate(maps[50], 186, 47, 189, 47, 0));
            targetGates.Add(253, this.CreateExitGate(maps[50], 186, 84, 189, 84, 0));
            targetGates.Add(255, this.CreateExitGate(maps[50], 169, 65, 169, 68, 0));
            targetGates.Add(260, this.CreateExitGate(maps[51], 26, 29, 27, 30, 0));
            targetGates.Add(262, this.CreateExitGate(maps[2], 161, 241, 163, 242, 0));
            targetGates.Add(264, this.CreateExitGate(maps[51], 243, 149, 244, 150, 0));
            targetGates.Add(266, this.CreateExitGate(maps[7], 16, 19, 17, 20, 0));
            targetGates.Add(275, this.CreateExitGate(maps[56], 189, 190, 191, 193, 0));
            targetGates.Add(278, this.CreateExitGate(maps[56], 204, 10, 206, 14, 0));
            targetGates.Add(281, this.CreateExitGate(maps[56], 65, 47, 67, 48, 0));
            targetGates.Add(284, this.CreateExitGate(maps[56], 62, 174, 63, 179, 0));
            return targetGates;
        }

        private EnterGate CreateEnterGate(short number, ExitGate targetGate, byte x1, byte y1, byte x2, byte y2, short levelRequirement)
        {
            var enterGate = this.repositoryManager.CreateNew<EnterGate>();
            enterGate.Number = number;
            enterGate.LevelRequirement = levelRequirement;
            enterGate.TargetGate = targetGate;
            enterGate.X1 = x1;
            enterGate.Y1 = y1;
            enterGate.X2 = x2;
            enterGate.Y2 = y2;
            enterGate.LevelRequirement = levelRequirement;
            return enterGate;
        }

        /// <summary>
        /// Creates the enter gates for all maps.
        /// </summary>
        /// <remarks>
        /// Regex: (?m)^(\d+)\s+?(1)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)\s+?(\d+)
        /// Replace by #2: maps[$3].Gates.Add(this.CreateEnterGate($1, targetGates[$8], $4, $5, $6, $7, $10));
        /// Remove other lines with empty replacement and regex: (?m)^\d+\s+.*$
        /// </remarks>
        /// <param name="maps">The maps.</param>
        /// <param name="targetGates">The target gates by number.</param>
        private void CreateEnterGates(IDictionary<short, GameMapDefinition> maps, IDictionary<short, ExitGate> targetGates)
        {
            maps[0].Gates.Add(this.CreateEnterGate(1, targetGates[2], 121, 232, 123, 233, 20));
            maps[1].Gates.Add(this.CreateEnterGate(3, targetGates[4], 108, 248, 109, 248, 0));
            maps[1].Gates.Add(this.CreateEnterGate(5, targetGates[6], 239, 149, 239, 150, 20));
            maps[1].Gates.Add(this.CreateEnterGate(7, targetGates[8], 232, 127, 233, 128, 20));
            maps[1].Gates.Add(this.CreateEnterGate(9, targetGates[10], 2, 17, 2, 18, 20));
            maps[1].Gates.Add(this.CreateEnterGate(11, targetGates[12], 2, 84, 2, 85, 20));
            maps[1].Gates.Add(this.CreateEnterGate(13, targetGates[14], 5, 34, 6, 34, 20));
            maps[1].Gates.Add(this.CreateEnterGate(15, targetGates[16], 29, 127, 30, 127, 20));
            maps[0].Gates.Add(this.CreateEnterGate(18, targetGates[19], 5, 38, 6, 41, 15));
            maps[2].Gates.Add(this.CreateEnterGate(20, targetGates[21], 244, 34, 245, 37, 0));
            maps[0].Gates.Add(this.CreateEnterGate(23, targetGates[24], 213, 246, 217, 247, 10));
            maps[3].Gates.Add(this.CreateEnterGate(25, targetGates[26], 148, 3, 155, 4, 10));
            maps[2].Gates.Add(this.CreateEnterGate(28, targetGates[29], 2, 248, 3, 249, 40));
            maps[4].Gates.Add(this.CreateEnterGate(30, targetGates[31], 190, 6, 191, 8, 40));
            maps[4].Gates.Add(this.CreateEnterGate(32, targetGates[33], 166, 163, 167, 166, 40));
            maps[4].Gates.Add(this.CreateEnterGate(34, targetGates[35], 132, 245, 135, 246, 50));
            maps[4].Gates.Add(this.CreateEnterGate(36, targetGates[37], 132, 135, 135, 136, 50));
            maps[4].Gates.Add(this.CreateEnterGate(38, targetGates[39], 131, 15, 132, 18, 50));
            maps[4].Gates.Add(this.CreateEnterGate(40, targetGates[41], 6, 5, 7, 8, 50));
            maps[4].Gates.Add(this.CreateEnterGate(43, targetGates[44], 162, 0, 166, 1, 15));
            maps[3].Gates.Add(this.CreateEnterGate(45, targetGates[46], 242, 240, 245, 243, 60));
            maps[7].Gates.Add(this.CreateEnterGate(47, targetGates[48], 9, 9, 11, 12, 60));
            maps[7].Gates.Add(this.CreateEnterGate(53, targetGates[54], 14, 225, 15, 230, 130));
            maps[8].Gates.Add(this.CreateEnterGate(55, targetGates[56], 246, 40, 247, 44, 130));
            maps[4].Gates.Add(this.CreateEnterGate(62, targetGates[63], 17, 250, 19, 250, 160));
            maps[10].Gates.Add(this.CreateEnterGate(64, targetGates[65], 14, 12, 16, 12, 50));
            maps[30].Gates.Add(this.CreateEnterGate(96, targetGates[97], 93, 242, 95, 243, 0));
            maps[30].Gates.Add(this.CreateEnterGate(98, targetGates[99], 160, 203, 161, 205, 0));
            maps[0].Gates.Add(this.CreateEnterGate(102, targetGates[103], 239, 14, 240, 15, 10));
            maps[30].Gates.Add(this.CreateEnterGate(107, targetGates[108], 28, 40, 28, 41, 0));
            maps[31].Gates.Add(this.CreateEnterGate(109, targetGates[110], 59, 7, 63, 8, 0));
            maps[30].Gates.Add(this.CreateEnterGate(117, targetGates[114], 161, 37, 165, 45, 10));
            maps[3].Gates.Add(this.CreateEnterGate(120, targetGates[113], 220, 30, 226, 30, 130));
            maps[33].Gates.Add(this.CreateEnterGate(121, targetGates[122], 74, 9, 74, 13, 10));
            maps[34].Gates.Add(this.CreateEnterGate(123, targetGates[124], 239, 40, 240, 44, 10));
            maps[8].Gates.Add(this.CreateEnterGate(125, targetGates[126], 6, 199, 6, 201, 150));
            maps[37].Gates.Add(this.CreateEnterGate(127, targetGates[128], 17, 220, 19, 222, 130));
            maps[37].Gates.Add(this.CreateEnterGate(129, targetGates[130], 89, 89, 89, 92, 220));
            maps[38].Gates.Add(this.CreateEnterGate(131, targetGates[132], 69, 104, 69, 107, 150));
            maps[45].Gates.Add(this.CreateEnterGate(160, targetGates[161], 136, 100, 137, 101, 0));
            maps[45].Gates.Add(this.CreateEnterGate(162, targetGates[163], 150, 117, 152, 119, 0));
            maps[45].Gates.Add(this.CreateEnterGate(164, targetGates[165], 149, 88, 151, 89, 0));
            maps[45].Gates.Add(this.CreateEnterGate(166, targetGates[167], 165, 101, 166, 104, 0));
            maps[45].Gates.Add(this.CreateEnterGate(168, targetGates[169], 173, 65, 174, 68, 0));
            maps[45].Gates.Add(this.CreateEnterGate(170, targetGates[171], 186, 79, 189, 81, 0));
            maps[45].Gates.Add(this.CreateEnterGate(172, targetGates[173], 186, 51, 188, 52, 0));
            maps[45].Gates.Add(this.CreateEnterGate(174, targetGates[175], 202, 66, 203, 68, 0));
            maps[46].Gates.Add(this.CreateEnterGate(176, targetGates[177], 136, 100, 137, 101, 0));
            maps[46].Gates.Add(this.CreateEnterGate(178, targetGates[179], 150, 117, 152, 119, 0));
            maps[46].Gates.Add(this.CreateEnterGate(180, targetGates[181], 149, 88, 151, 89, 0));
            maps[46].Gates.Add(this.CreateEnterGate(182, targetGates[183], 165, 101, 166, 104, 0));
            maps[46].Gates.Add(this.CreateEnterGate(184, targetGates[185], 173, 65, 174, 68, 0));
            maps[46].Gates.Add(this.CreateEnterGate(186, targetGates[187], 186, 79, 189, 81, 0));
            maps[46].Gates.Add(this.CreateEnterGate(188, targetGates[189], 186, 51, 188, 52, 0));
            maps[46].Gates.Add(this.CreateEnterGate(190, targetGates[191], 202, 66, 203, 68, 0));
            maps[47].Gates.Add(this.CreateEnterGate(192, targetGates[193], 136, 100, 137, 101, 0));
            maps[47].Gates.Add(this.CreateEnterGate(194, targetGates[195], 150, 117, 152, 119, 0));
            maps[47].Gates.Add(this.CreateEnterGate(196, targetGates[197], 149, 88, 151, 89, 0));
            maps[47].Gates.Add(this.CreateEnterGate(198, targetGates[199], 165, 101, 166, 104, 0));
            maps[47].Gates.Add(this.CreateEnterGate(200, targetGates[201], 173, 65, 174, 68, 0));
            maps[47].Gates.Add(this.CreateEnterGate(202, targetGates[203], 186, 79, 189, 81, 0));
            maps[47].Gates.Add(this.CreateEnterGate(204, targetGates[205], 186, 51, 188, 52, 0));
            maps[47].Gates.Add(this.CreateEnterGate(206, targetGates[207], 202, 66, 203, 68, 0));
            maps[48].Gates.Add(this.CreateEnterGate(208, targetGates[209], 136, 100, 137, 101, 0));
            maps[48].Gates.Add(this.CreateEnterGate(210, targetGates[211], 150, 117, 152, 119, 0));
            maps[48].Gates.Add(this.CreateEnterGate(212, targetGates[213], 149, 88, 151, 89, 0));
            maps[48].Gates.Add(this.CreateEnterGate(214, targetGates[215], 165, 101, 166, 104, 0));
            maps[48].Gates.Add(this.CreateEnterGate(216, targetGates[217], 173, 65, 174, 68, 0));
            maps[48].Gates.Add(this.CreateEnterGate(218, targetGates[219], 186, 79, 189, 81, 0));
            maps[48].Gates.Add(this.CreateEnterGate(220, targetGates[221], 186, 51, 188, 52, 0));
            maps[48].Gates.Add(this.CreateEnterGate(222, targetGates[223], 202, 66, 203, 68, 0));
            maps[49].Gates.Add(this.CreateEnterGate(224, targetGates[225], 136, 100, 137, 101, 0));
            maps[49].Gates.Add(this.CreateEnterGate(226, targetGates[227], 150, 117, 152, 119, 0));
            maps[49].Gates.Add(this.CreateEnterGate(228, targetGates[229], 149, 88, 151, 89, 0));
            maps[49].Gates.Add(this.CreateEnterGate(230, targetGates[231], 165, 101, 166, 104, 0));
            maps[49].Gates.Add(this.CreateEnterGate(232, targetGates[233], 173, 65, 174, 68, 0));
            maps[49].Gates.Add(this.CreateEnterGate(234, targetGates[235], 186, 79, 189, 81, 0));
            maps[49].Gates.Add(this.CreateEnterGate(236, targetGates[237], 186, 51, 188, 52, 0));
            maps[49].Gates.Add(this.CreateEnterGate(238, targetGates[239], 202, 66, 203, 68, 0));
            maps[50].Gates.Add(this.CreateEnterGate(240, targetGates[241], 136, 100, 137, 101, 0));
            maps[50].Gates.Add(this.CreateEnterGate(242, targetGates[243], 150, 117, 152, 119, 0));
            maps[50].Gates.Add(this.CreateEnterGate(244, targetGates[245], 149, 88, 151, 89, 0));
            maps[50].Gates.Add(this.CreateEnterGate(246, targetGates[247], 165, 101, 166, 104, 0));
            maps[50].Gates.Add(this.CreateEnterGate(248, targetGates[249], 173, 65, 174, 68, 0));
            maps[50].Gates.Add(this.CreateEnterGate(250, targetGates[251], 186, 79, 189, 81, 0));
            maps[50].Gates.Add(this.CreateEnterGate(252, targetGates[253], 186, 51, 188, 52, 0));
            maps[50].Gates.Add(this.CreateEnterGate(254, targetGates[255], 202, 66, 203, 68, 0));
            maps[2].Gates.Add(this.CreateEnterGate(259, targetGates[260], 161, 245, 166, 246, 15));
            maps[51].Gates.Add(this.CreateEnterGate(261, targetGates[262], 24, 29, 25, 30, 15));
            maps[7].Gates.Add(this.CreateEnterGate(263, targetGates[264], 13, 19, 14, 20, 10));
            maps[51].Gates.Add(this.CreateEnterGate(265, targetGates[266], 247, 149, 248, 150, 60));
            maps[56].Gates.Add(this.CreateEnterGate(274, targetGates[275], 139, 125, 139, 126, 250));
            maps[56].Gates.Add(this.CreateEnterGate(276, targetGates[273], 185, 187, 186, 188, 250));
            maps[56].Gates.Add(this.CreateEnterGate(277, targetGates[278], 149, 109, 150, 109, 250));
            maps[56].Gates.Add(this.CreateEnterGate(279, targetGates[273], 197, 12, 197, 14, 250));
            maps[56].Gates.Add(this.CreateEnterGate(280, targetGates[281], 139, 95, 140, 95, 250));
            maps[56].Gates.Add(this.CreateEnterGate(282, targetGates[273], 68, 52, 69, 53, 250));
            maps[56].Gates.Add(this.CreateEnterGate(283, targetGates[284], 124, 109, 124, 110, 250));
            maps[56].Gates.Add(this.CreateEnterGate(285, targetGates[273], 57, 176, 57, 177, 250));
            maps[2].Gates.Add(this.CreateEnterGate(286, targetGates[287], 52, 92, 54, 92, 240));
            maps[57].Gates.Add(this.CreateEnterGate(288, targetGates[289], 223, 215, 225, 215, 240));
            maps[57].Gates.Add(this.CreateEnterGate(290, targetGates[291], 171, 23, 171, 25, 240));
            maps[58].Gates.Add(this.CreateEnterGate(292, targetGates[293], 167, 24, 167, 25, 240));
            maps[69].Gates.Add(this.CreateEnterGate(308, targetGates[309], 209, 80, 211, 82, 0));
            maps[69].Gates.Add(this.CreateEnterGate(310, targetGates[311], 153, 60, 156, 63, 0));
            maps[70].Gates.Add(this.CreateEnterGate(313, targetGates[314], 10, 64, 12, 66, 0));
            maps[70].Gates.Add(this.CreateEnterGate(315, targetGates[316], 54, 161, 56, 163, 0));
            maps[71].Gates.Add(this.CreateEnterGate(318, targetGates[319], 82, 194, 84, 196, 0));
            maps[71].Gates.Add(this.CreateEnterGate(320, targetGates[321], 222, 201, 224, 203, 0));
            maps[72].Gates.Add(this.CreateEnterGate(323, targetGates[324], 30, 95, 32, 97, 0));
            maps[72].Gates.Add(this.CreateEnterGate(325, targetGates[326], 68, 160, 70, 162, 0));
            maps[72].Gates.Add(this.CreateEnterGate(327, targetGates[328], 223, 165, 225, 167, 0));
        }
    }
}
