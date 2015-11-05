<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:o="urn:schemas-microsoft-com:office:office"
xmlns:x="urn:schemas-microsoft-com:office:excel"
xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
xmlns:html="http://www.w3.org/TR/REC-html40"
xmlns:myObj="urn:ms-kb">

  <xsl:template match="/ReportDataSet">
    <Workbook>
      <Styles>
        <Style ss:ID="Default" ss:Name="Normal">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s18" ss:Name="Normal 2 2 2 2 8">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s17" ss:Name="Normal 2 3">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s59" ss:Name="Normal 2 3 2 7">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Arial" x:Family="Swiss"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s144" ss:Name="Normal 5">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s16" ss:Name="Normal_KH 2003">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s147" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s148">
          <Alignment ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s149" ss:Parent="s17">
          <Alignment ss:Horizontal="CenterAcrossSelection" ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1" ss:Italic="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s150" ss:Parent="s17">
          <Alignment ss:Horizontal="CenterAcrossSelection" ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s151" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1" ss:Italic="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s152" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#002060" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s153" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s154">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Calibri" x:Family="Swiss"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s155">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s156">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s157">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" ss:Size="11"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s158" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFCC" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s159">
          <Alignment ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s160" ss:Parent="s144">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:Indent="2"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s161" ss:Parent="s144">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s162" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="16" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s163">
          <Alignment ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s164">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s165" ss:Parent="s16">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s166">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s167">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s168" ss:Parent="s17">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#002060" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s169" ss:Parent="s17">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#002060" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s170" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#002060" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s171">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Swiss" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s172" ss:Parent="s59">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s173">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Swiss" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s174" ss:Parent="s59">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s175">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s176" ss:Parent="s144">
          <Alignment ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s177">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
        </Style>
        <Style ss:ID="s178">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s179">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
        </Style>
        <Style ss:ID="s180">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s181">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s182">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
          <Interior/>
        </Style>
        <Style ss:ID="s183">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s184">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s185">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
        </Style>
        <Style ss:ID="s186">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:CharSet="163" x:Family="Roman" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s187">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s188">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s189">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:Indent="2"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
        </Style>
        <Style ss:ID="s190">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Swiss" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s191">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Swiss" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s192">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
          <Interior/>
        </Style>
        <Style ss:ID="s193">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
        </Style>
        <Style ss:ID="s194">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"
           ss:Color="#FF0000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s195" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s196">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s197">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s198">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s199">
          <Alignment ss:Vertical="Center"/>
          <Interior/>
        </Style>
        <Style ss:ID="s200">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" ss:Size="11"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s201">
          <Alignment ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" ss:Size="11"/>
          <Interior/>
        </Style>
        <Style ss:ID="s202">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s203">
          <Alignment ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s204">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s205">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" ss:Size="11"/>
          <Interior/>
        </Style>
        <Style ss:ID="s206">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FF0000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s207">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FF0000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s208">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"
           ss:Color="#FF0000"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s209">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s210" ss:Parent="s16">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s211" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s212">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s213">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s214">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s215" ss:Parent="s17">
          <Alignment ss:Horizontal="CenterAcrossSelection" ss:Vertical="Center"
           ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1" ss:Italic="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s216" ss:Parent="s17">
          <Alignment ss:Horizontal="CenterAcrossSelection" ss:Vertical="Center"
           ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s217" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1" ss:Italic="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s218">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s219">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s220">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
          <NumberFormat ss:Format="d\-mmm"/>
        </Style>
        <Style ss:ID="s221">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Bold="1"/>
          <Interior ss:Color="#FFFFCC" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s222">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s223">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Color="#FF0000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s224">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <NumberFormat ss:Format="d\-mmm"/>
        </Style>
        <Style ss:ID="s225">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="d\-mmm"/>
        </Style>
        <Style ss:ID="s226">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s229" ss:Parent="s17">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s230">
          <Alignment ss:Vertical="Center"/>
          <Font ss:FontName="Times New Roman" ss:Size="11"/>
          <Interior/>
        </Style>
        <Style ss:ID="s231">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman"/>
          <Interior/>
        </Style>
        <Style ss:ID="s232">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="12"/>
          <Interior/>
        </Style>
        <Style ss:ID="s234" ss:Parent="s16">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="16" ss:Bold="1"/>
          <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        </Style>
      </Styles>

      <Worksheet ss:Name="KHHD_DK">
        <Table  x:FullColumns="1" x:FullRows="1" ss:StyleID="s171">
          <Column ss:StyleID="s190" ss:AutoFitWidth="0" ss:Width="26.25"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="64.5"/>
          <Column ss:StyleID="s171" ss:Width="49.5"/>
          <Column ss:StyleID="s190" ss:Width="51"/>
          <Column ss:StyleID="s171" ss:Width="393.75"/>
          <Column ss:StyleID="s190" ss:AutoFitWidth="0" ss:Width="91.5"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="357.75"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="57.75"/>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s163">
              <Data ss:Type="String">TẬP ĐOÀN TRUYỀN THÔNG VMG</Data>
            </Cell>
            <Cell ss:StyleID="s163"/>
            <Cell ss:StyleID="s163"/>
            <Cell ss:StyleID="s164"/>
            <Cell ss:StyleID="s165"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s165"/>
            <Cell ss:StyleID="s165"/>
          </Row>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s148">
              <Data ss:Type="String">PHÒNG PHÁT TRIỂN DỊCH VỤ</Data>
            </Cell>
            <Cell ss:StyleID="s148"/>
            <Cell ss:StyleID="s148"/>
            <Cell ss:StyleID="s167"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
          </Row>
          <Row ss:Height="20.25" ss:StyleID="s166">
            <Cell ss:MergeAcross="6" ss:StyleID="s162">
              <Data ss:Type="String">KẾ HOẠCH HÀNH ĐỘNG ĐỊNH KỲ 6 THÁNG CUỐI NĂM 2015</Data>
            </Cell>
            <Cell ss:StyleID="s162"/>
          </Row>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s151"/>
            <Cell ss:StyleID="s150"/>
            <Cell ss:StyleID="s151"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="24.9375">
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">STT</Data>
            </Cell>
            <Cell ss:StyleID="s169">
              <Data ss:Type="String">Mã ĐV</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Mã Nhóm</Data>
            </Cell>
            <Cell ss:StyleID="s170">
              <Data ss:Type="String">Mã DV</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Tên Công Việc</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Thời gian</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Chỉ tiêu đánh giá HTCV</Data>
            </Cell>
            <Cell ss:StyleID="s152">
              <Data ss:Type="String">Kết quả quý</Data>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Trạng thái thay đổi</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <B>
                    <Font
         html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Mô tả:&#10;</Font>
                  </B>
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Có 3 trạng thái:&#10;- H: Hủy công việc &#45;-&gt; Comment lý do hủy công việc&#10;- PS: Công việc phát sinh mới &#45;-&gt; Công việc PS sẽ được insert 1 dòng mới và điền đầy đủ thông tin trong các cột từ A đến H&#10;- TĐ: Đề xuất thay đổi nội dung công việc &#45;-&gt; Các nội dung thay đổi được điền vào các cột bôi vàng, thay đổi có thể ở 1 hoặc cả 2 tiêu chí &#10;&#10;Highlight màu đỏ các dòng công việc có trạng thái H, PS, TĐ</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi thời gian thực hiện</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền thời gian đề xuất thay đổi</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi &quot;Nội dung công việc&quot;</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền nội dung thay đổi về &quot;Nội dung công việc&quot;</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi &quot;Chỉ tiêu đánh giá hoàn thành công việc&quot;</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền nội dung thay đổi về &quot;Chỉ tiêu đánh giá HTCV&quot; </Font>
                </ss:Data>
              </Comment>
            </Cell>
          </Row>
          
          <xsl:apply-templates select="KHHD_DK/Table"></xsl:apply-templates>
        </Table>
      </Worksheet>
      <Worksheet ss:Name="KHHD_PS">
        <Table  x:FullColumns="1" x:FullRows="1" ss:StyleID="s171">
          <Column ss:StyleID="s190" ss:AutoFitWidth="0" ss:Width="26.25"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="64.5"/>
          <Column ss:StyleID="s171" ss:Width="49.5"/>
          <Column ss:StyleID="s190" ss:Width="51"/>
          <Column ss:StyleID="s171" ss:Width="393.75"/>
          <Column ss:StyleID="s190" ss:AutoFitWidth="0" ss:Width="91.5"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="357.75"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="57.75"/>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s163">
              <Data ss:Type="String">TẬP ĐOÀN TRUYỀN THÔNG VMG</Data>
            </Cell>
            <Cell ss:StyleID="s163"/>
            <Cell ss:StyleID="s163"/>
            <Cell ss:StyleID="s164"/>
            <Cell ss:StyleID="s165"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s165"/>
            <Cell ss:StyleID="s165"/>
          </Row>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s148">
              <Data ss:Type="String">PHÒNG PHÁT TRIỂN DỊCH VỤ</Data>
            </Cell>
            <Cell ss:StyleID="s148"/>
            <Cell ss:StyleID="s148"/>
            <Cell ss:StyleID="s167"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
          </Row>
          <Row ss:Height="20.25" ss:StyleID="s166">
            <Cell ss:MergeAcross="6" ss:StyleID="s162">
              <Data ss:Type="String">KẾ HOẠCH HÀNH ĐỘNG ĐỊNH KỲ 6 THÁNG CUỐI NĂM 2015</Data>
            </Cell>
            <Cell ss:StyleID="s162"/>
          </Row>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s151"/>
            <Cell ss:StyleID="s150"/>
            <Cell ss:StyleID="s151"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="24.9375">
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">STT</Data>
            </Cell>
            <Cell ss:StyleID="s169">
              <Data ss:Type="String">Mã ĐV</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Mã Nhóm</Data>
            </Cell>
            <Cell ss:StyleID="s170">
              <Data ss:Type="String">Mã DV</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Tên Công Việc</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Thời gian</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Chỉ tiêu đánh giá HTCV</Data>
            </Cell>
            <Cell ss:StyleID="s152">
              <Data ss:Type="String">Kết quả quý</Data>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Trạng thái thay đổi</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <B>
                    <Font
         html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Mô tả:&#10;</Font>
                  </B>
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Có 3 trạng thái:&#10;- H: Hủy công việc &#45;-&gt; Comment lý do hủy công việc&#10;- PS: Công việc phát sinh mới &#45;-&gt; Công việc PS sẽ được insert 1 dòng mới và điền đầy đủ thông tin trong các cột từ A đến H&#10;- TĐ: Đề xuất thay đổi nội dung công việc &#45;-&gt; Các nội dung thay đổi được điền vào các cột bôi vàng, thay đổi có thể ở 1 hoặc cả 2 tiêu chí &#10;&#10;Highlight màu đỏ các dòng công việc có trạng thái H, PS, TĐ</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi thời gian thực hiện</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền thời gian đề xuất thay đổi</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi &quot;Nội dung công việc&quot;</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền nội dung thay đổi về &quot;Nội dung công việc&quot;</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi &quot;Chỉ tiêu đánh giá hoàn thành công việc&quot;</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền nội dung thay đổi về &quot;Chỉ tiêu đánh giá HTCV&quot; </Font>
                </ss:Data>
              </Comment>
            </Cell>
          </Row>

          <xsl:apply-templates select="KHHD_PS/Table"></xsl:apply-templates>
        </Table>
      </Worksheet>
      <Worksheet ss:Name="CVC">
        <Table  x:FullColumns="1" x:FullRows="1" ss:StyleID="s171">
          <Column ss:StyleID="s190" ss:AutoFitWidth="0" ss:Width="26.25"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="64.5"/>
          <Column ss:StyleID="s171" ss:Width="49.5"/>
          <Column ss:StyleID="s190" ss:Width="51"/>
          <Column ss:StyleID="s171" ss:Width="393.75"/>
          <Column ss:StyleID="s190" ss:AutoFitWidth="0" ss:Width="91.5"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="357.75"/>
          <Column ss:StyleID="s171" ss:AutoFitWidth="0" ss:Width="57.75"/>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s163">
              <Data ss:Type="String">TẬP ĐOÀN TRUYỀN THÔNG VMG</Data>
            </Cell>
            <Cell ss:StyleID="s163"/>
            <Cell ss:StyleID="s163"/>
            <Cell ss:StyleID="s164"/>
            <Cell ss:StyleID="s165"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s165"/>
            <Cell ss:StyleID="s165"/>
          </Row>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s148">
              <Data ss:Type="String">PHÒNG PHÁT TRIỂN DỊCH VỤ</Data>
            </Cell>
            <Cell ss:StyleID="s148"/>
            <Cell ss:StyleID="s148"/>
            <Cell ss:StyleID="s167"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
            <Cell ss:StyleID="s147"/>
          </Row>
          <Row ss:Height="20.25" ss:StyleID="s166">
            <Cell ss:MergeAcross="6" ss:StyleID="s162">
              <Data ss:Type="String">KẾ HOẠCH HÀNH ĐỘNG ĐỊNH KỲ 6 THÁNG CUỐI NĂM 2015</Data>
            </Cell>
            <Cell ss:StyleID="s162"/>
          </Row>
          <Row ss:Height="15" ss:StyleID="s166">
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s151"/>
            <Cell ss:StyleID="s150"/>
            <Cell ss:StyleID="s151"/>
            <Cell ss:StyleID="s149"/>
            <Cell ss:StyleID="s149"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="24.9375">
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">STT</Data>
            </Cell>
            <Cell ss:StyleID="s169">
              <Data ss:Type="String">Mã ĐV</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Mã Nhóm</Data>
            </Cell>
            <Cell ss:StyleID="s170">
              <Data ss:Type="String">Mã DV</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Tên Công Việc</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Thời gian</Data>
            </Cell>
            <Cell ss:StyleID="s168">
              <Data ss:Type="String">Chỉ tiêu đánh giá HTCV</Data>
            </Cell>
            <Cell ss:StyleID="s152">
              <Data ss:Type="String">Kết quả quý</Data>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Trạng thái thay đổi</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <B>
                    <Font
         html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Mô tả:&#10;</Font>
                  </B>
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Có 3 trạng thái:&#10;- H: Hủy công việc &#45;-&gt; Comment lý do hủy công việc&#10;- PS: Công việc phát sinh mới &#45;-&gt; Công việc PS sẽ được insert 1 dòng mới và điền đầy đủ thông tin trong các cột từ A đến H&#10;- TĐ: Đề xuất thay đổi nội dung công việc &#45;-&gt; Các nội dung thay đổi được điền vào các cột bôi vàng, thay đổi có thể ở 1 hoặc cả 2 tiêu chí &#10;&#10;Highlight màu đỏ các dòng công việc có trạng thái H, PS, TĐ</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi thời gian thực hiện</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền thời gian đề xuất thay đổi</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi &quot;Nội dung công việc&quot;</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền nội dung thay đổi về &quot;Nội dung công việc&quot;</Font>
                </ss:Data>
              </Comment>
            </Cell>
            <Cell ss:StyleID="s158">
              <Data ss:Type="String">Thay đổi &quot;Chỉ tiêu đánh giá hoàn thành công việc&quot;</Data>
              <Comment
      ss:Author="Author">
                <ss:Data xmlns="http://www.w3.org/TR/REC-html40">
                  <Font
        html:Face="Tahoma" x:Family="Swiss" html:Size="9" html:Color="#000000">Điền nội dung thay đổi về &quot;Chỉ tiêu đánh giá HTCV&quot; </Font>
                </ss:Data>
              </Comment>
            </Cell>
          </Row>

          <xsl:apply-templates select="CVC/Table"></xsl:apply-templates>
        </Table>
      </Worksheet>
    </Workbook>
  </xsl:template>

  <xsl:template match="Table">
    <Row ss:AutoFitHeight="0" ss:Height="24.9375" ss:StyleID="s154">
      <Cell ss:StyleID="s172">
        <Data ss:Type="Number">
          <xsl:value-of select="STT"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s173">
        <Data ss:Type="String">
          <xsl:value-of select="MaDonVi"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s174">
        <Data ss:Type="String">
          <xsl:value-of select="MaNhom"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s175">
        <Data ss:Type="String">
          <xsl:value-of select="MaDV"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s176">
        <Data ss:Type="String">
          <xsl:value-of select="NoiDungCongViec"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s177">
        <Data ss:Type="String">
          <xsl:value-of select="ThoiGianThucHien"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s178">
        <Data ss:Type="String">
          <xsl:value-of select="ChiTieuDanhGiaHTCV"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s181">
        <Data ss:Type="String">
          <xsl:value-of select="KetQuaQuy"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s159">
        <Data ss:Type="String">
          <xsl:value-of select="TrangThaiThayDoi"/>
        </Data>
      </Cell>
      <Cell ss:StyleID="s159">
        <xsl:value-of select="ThayDoiThoiGianThucHien"/>
      </Cell>
      <Cell ss:StyleID="s159">
        <xsl:value-of select="ThayDoiNoiDungCongViec"/>
      </Cell>
      <Cell ss:StyleID="s159">
        <xsl:value-of select="ThayDoiChiTieuDanhGiaCongViec"/>
      </Cell>
    </Row>   
  </xsl:template>
</xsl:stylesheet>