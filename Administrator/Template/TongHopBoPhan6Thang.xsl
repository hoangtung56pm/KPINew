<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:html="http://www.w3.org/TR/REC-html40"
xmlns:myObj="urn:ms-kb">

  <xsl:template match="/NewDataSet">
    <Workbook>
      <Styles>
        <Style ss:ID="Default" ss:Name="Normal">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s16" ss:Name="Percent">
          <NumberFormat ss:Format="0%"/>
        </Style>
        <Style ss:ID="m191822456">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
        </Style>
        <Style ss:ID="m191822476">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s21">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s24">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
        </Style>
        <Style ss:ID="s25">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s26">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s31" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
        </Style>
        <Style ss:ID="s41">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          
        </Style>
        <Style ss:ID="s40">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s42">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s43">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s44">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <NumberFormat ss:Format="#,##0.0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s45">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s46">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s47">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s48">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s49">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s50" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s51" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="0.0%"/>
        </Style>
        <Style ss:ID="s52">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s53">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s54">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s55">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s56">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s57" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
        </Style>
        <Style ss:ID="s58" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="#,##0.0"/>
        </Style>
        <Style ss:ID="s59" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="Percent"/>
        </Style>
        <Style ss:ID="s60">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s61">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s103">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11"/>
        </Style>
        <Style ss:ID="s63" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="Percent"/>
        </Style>
        <Style ss:ID="s222" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <NumberFormat ss:Format="0.0%"/>
        </Style>
        <Style ss:ID="s308">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Italic="1"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s309">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Italic="1"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s310">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1" ss:Italic="1"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s311">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1" ss:Italic="1"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s312">
          <Alignment ss:Vertical="Bottom"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Italic="1"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s385">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Italic="1"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s610">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s616">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="16" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s617">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
        </Style>
      </Styles>
      <Worksheet ss:Name="tong hop bo phan">
        <Table ss:ExpandedColumnCount="22" 
         x:FullRows="1" ss:StyleID="s21" ss:DefaultRowHeight="14.25">
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s40" ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="50"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:StyleID="s41" ss:AutoFitWidth="0" ss:Width="150"/>
          <Row>
            <Cell>
              <Data ss:Type="String">CÔNG TY CỔ PHẦN TRUYỀN THÔNG VMG</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="24">
            <Cell ss:MergeAcross="21" ss:StyleID="s616">
              <Data ss:Type="String">BẢNG TỔNG HỢP CHI TIẾT XẾP LOẠI BỘ PHẬN</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="4.5">
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
            <Cell ss:StyleID="s24"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="13.5">
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">STT</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">TÊN BỘ PHẬN</Data>
            </Cell>
            <Cell ss:MergeAcross="12" ss:StyleID="s617">
              <Data ss:Type="String">ĐIỂM ĐÁNH GIÁ</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">XẾP LOẠI</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="m191822456">
              <Data ss:Type="String">SỐ LƯỢNG NHÂN SỰ</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="m191822476">
              <Data ss:Type="String">MỨC KHEN THƯỞNG</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">ĐÁNH GIÁ CỦA CEO</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">THÀNH TÍCH NỔI BẬT</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">CÔNG VIỆC CHƯA HOÀN THÀNH</Data>
            </Cell>
            <Cell ss:MergeDown="2" ss:StyleID="s610">
              <Data ss:Type="String">ĐỀ XUẤT VỚI LÃNH ĐẠO</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="38.25" ss:StyleID="s26">
            <Cell ss:Index="3" ss:MergeAcross="2" ss:StyleID="s610">
              <Data ss:Type="String">I. NHIỆM VỤ BỘ PHẬN (70%)</Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="s610">
              <Data ss:Type="String">II. PHỐI HỢP VỚI CÁC ĐƠN VỊ KHÁC (15%)</Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="s610">
              <Data ss:Type="String">III. KỶ LUẬT VÀ VĂN HÓA BỘ PHẬN (15%)</Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="s610">
              <Data ss:Type="String">IV. TỔNG ĐIỂM</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15" ss:StyleID="s26">
            <Cell ss:Index="3" ss:StyleID="s46">
              <Data ss:Type="String">A</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">B</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">C</Data>
            </Cell>
            <Cell ss:StyleID="s47">
              <Data ss:Type="String">Điểm</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">A</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">B</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">C</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">A</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">B</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">C</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">A</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">B</Data>
            </Cell>
            <Cell ss:StyleID="s46">
              <Data ss:Type="String">C</Data>
            </Cell>
          </Row>

          <xsl:apply-templates select="Table"></xsl:apply-templates>
         
          <Row ss:AutoFitHeight="0" ss:Height="23.25" ss:StyleID="s308">
            <Cell ss:StyleID="s312">
              <Data ss:Type="String">- Tổng kết xếp loại:</Data>
            </Cell>
            <Cell ss:StyleID="s309"/>
            <Cell ss:Index="18" ss:StyleID="s385">
              <Data ss:Type="Number"></Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Loại A: đạt  từ 70% chỉ tiêu A và 0% chỉ tiêu C</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Loại B: đạt từ 70% chỉ tiêu B và 0% chỉ tiêu C hoặc đạt từ 30% chỉ tiêu A trở lên và dưới 15% chỉ tiêu C</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Loại C: các trường hợp khác.</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="21" ss:StyleID="s308">
            <Cell ss:StyleID="s312">
              <Data ss:Type="String">- Đối với bộ phận kinh doanh: điểm cho phần Nhiệm vụ bộ phận được tính theo tỷ lệ doanh thu lợi nhuận đạt được như sau:</Data>
            </Cell>
            <Cell ss:StyleID="s309"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Mức A: đạt  90% - 100% so với yêu cầu (hoặc kế hoạch công việc).</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Mức B: đạt 80% - 89% so với yêu cầu (hoặc kế hoạch công việc).</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Mức C: đạt &lt; 80% so với yêu cầu (hoặc kế hoạch công việc).</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="16.5" ss:StyleID="s308">
            <Cell ss:StyleID="s312">
              <Data ss:Type="String">- Điểm cho phần Phối hợp với các đơn vị khác được tổng hợp từ điểm đánh giá của CBNV Công ty và áp theo thang điểm như sau:</Data>
            </Cell>
            <Cell ss:StyleID="s309"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Mức A: 3 -4 điểm</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Mức B:  2-3 điểm</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75" ss:StyleID="s310">
            <Cell ss:Index="2" ss:StyleID="s311">
              <Data ss:Type="String">* Mức C: &lt;2 điểm</Data>
            </Cell>
          </Row>
          <Row >
            <Cell ss:Index="2" ss:StyleID="s25"/>
          </Row>
          <Row >
            <Cell ss:Index="2" ss:StyleID="s25"/>
          </Row>
        </Table>

      </Worksheet>
    </Workbook>
  </xsl:template>

  <xsl:template match="Table">
    <Row >
      <Cell ss:StyleID="s48">
        <Data ss:Type="String">
          <xsl:value-of select="STT"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s49">
        <Data ss:Type="String">
          <xsl:value-of select="TenTrungTam"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="NhiemVuBoPhanA"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="NhiemVuBoPhanB"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="NhiemVuBoPhanC"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s44">
        <Data ss:Type="Number">
          <xsl:value-of select="PhoiHopBoPhanKhacDiem"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="PhoiHopBoPhanKhacA"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="PhoiHopBoPhanKhacB"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="PhoiHopBoPhanKhacC"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="KyLuatA"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="KyLuatB"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="KyLuatC"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42" >
        <Data ss:Type="String">
          <xsl:value-of select="TongA"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data  ss:Type="String">
          <xsl:value-of select="TongB"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s42">
        <Data ss:Type="String">
          <xsl:value-of select="TongC"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s48">
        <Data ss:Type="String">
          <xsl:value-of select="XepLoai"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s48">
        <Data ss:Type="String">
          <xsl:value-of select="SoNhanVien"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s49">
        <Data ss:Type="String">

        </Data>
      </Cell>
      <Cell ss:StyleID="s49">
        <Data ss:Type="String">

        </Data>
      </Cell>
      <Cell ss:StyleID="s49">
        <Data ss:Type="String">
          <xsl:value-of select="ThanhTichNoiBat"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s49">
        <Data ss:Type="String">
          <xsl:value-of select="CongViecChuaHoanThanh"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s49">
        <Data ss:Type="String">
          <xsl:value-of select="DeXuatVoiLanhDao"/>
        </Data>
      </Cell>
    </Row>

  </xsl:template>
  
</xsl:stylesheet>


